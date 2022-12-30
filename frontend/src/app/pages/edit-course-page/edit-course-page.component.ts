import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppService } from 'src/app/app.service';
import { AppState } from 'src/app/store/states/app.state';
import { CourseType, Module } from 'src/typings/api/courseType';
import { CourseMenuItem } from 'src/typings/courseMenuItemType';
import { ModuleInfo } from 'src/typings/module';

@Component({
  selector: 'app-edit-course-page',
  templateUrl: './edit-course-page.component.html',
  styleUrls: ['./edit-course-page.component.scss']
})
export class EditCoursePageComponent implements OnInit {
  courseInfo: CourseType | null = null;
  currentCourseId: string = '';
  currentModuleId: string = '';
  currentLessonId: number | null = null;
  currentModuleIndex: number | null = null;

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) { 
    
  }

  ngOnInit(): void {
    this.activeRouter.queryParamMap.subscribe((param) => {
      const courseId = param.get('courseId');
      const moduleId = param.get('moduleId');
      if(courseId) {
        this.currentCourseId = courseId;
      } 
      if(moduleId) {
        this.currentModuleId = moduleId;
      }
      if(!courseId && !moduleId) {
        alert('Что то не так с ids');
      }
   })
   this.getCourseInfo();
  }

  async getCourseInfo() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}`, {
      credentials: 'include',
    })
    const data = await response.json() as CourseType;
    this.courseInfo = data;
    if(this.currentModuleId) {
      this.setCurrentOpenModule();
    }
  }

  createModule() {
    this.router.navigate(['/create-module'], {queryParams: {courseId: this.currentCourseId}});
  }

  setCurrentOpenModule() {
    if(this.courseInfo) {
      this.currentModuleIndex = this.courseInfo?.modules.findIndex((module) => module.id === this.currentModuleId)
    }
  }

  createLesson() {
    this.router.navigate(['/edit-course/select-lesson-type'], {
      queryParamsHandling: 'merge',
      queryParams: {
        lessonId: null
      }
    });
  }

  async onClickModule({ moduleId, moduleIndex }: ModuleInfo) {
    await this.getCourseInfo();
    this.currentModuleId = moduleId;
    this.currentModuleIndex = moduleIndex;
    const lesson = this.courseInfo?.modules[moduleIndex].lessons[0]?.id || null;
    if(lesson !== null) {
      this.router.navigate(['/edit-course/edit-text-lesson'], {
        queryParams: {
          moduleId: this.currentModuleId,
          lessonId: lesson,
        },
        queryParamsHandling: 'merge',
      });
    } else {
      this.router.navigate(['/edit-course/select-lesson-type'], {
        queryParams: {
          moduleId: this.currentModuleId,
          lessonId: lesson,
        },
        queryParamsHandling: 'merge',
      });
    }
    
  }

  async onClickLesson(lessonId: number) {
    await this.router.navigate(['/edit-course/edit-text-lesson'], {
      queryParamsHandling: 'merge',
      queryParams: {lessonId},
    });
  }
}
