import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, ParamMap, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
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
    this.onChangeUrl();
  }

  async onChangeUrl() {
    this.router.events.pipe(filter((e) => e instanceof NavigationEnd)).subscribe(async (e) => {
      const event = e as NavigationEnd;
      const params = event.url.split('&');
      const lessonIdString = params.find((param) => param.includes('lessonId'));
      if(lessonIdString) {
        this.getCourseInfo();
        this.currentLessonId = +lessonIdString.split('=')[1];
        this.onClickLesson(this.currentLessonId);
      }
      if(this.currentCourseId && this.currentModuleId) {
      }
    })
  }

  async ngOnInit(): Promise<void> {
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
   await this.getCourseInfo();
    if(this.currentModuleId) {
      this.setCurrentOpenModule();
    }
  }

  async getCourseInfo() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}`, {
      credentials: 'include',
    })
    const data = await response.json() as CourseType;
    this.courseInfo = data;
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
    this.setCurrentOpenModule();
    this.currentModuleId = moduleId;
    this.currentModuleIndex = moduleIndex;
    const lessonId = this.courseInfo?.modules[moduleIndex].lessons[0]?.id || null;
    if(lessonId !== null) {
      const editUrlPage = this.getLessonTypeUrl(moduleIndex, lessonId)
      this.router.navigate([editUrlPage], {
        queryParams: {
          moduleId: this.currentModuleId,
          lessonId: lessonId,
        },
        queryParamsHandling: 'merge',
      });
    } else {
      this.router.navigate(['/edit-course/select-lesson-type'], {
        queryParams: {
          moduleId: this.currentModuleId,
          lessonId: lessonId,
        },
        queryParamsHandling: 'merge',
      });
    }
    
  }

  async onClickLesson(lessonId: number) {
    if(this.currentModuleIndex === null) {
      return;
    }
    this.currentLessonId = lessonId;
    const editPageUrl = this.getLessonTypeUrl(this.currentModuleIndex, lessonId);
    if(editPageUrl) {
      await this.router.navigate([editPageUrl], {
        queryParamsHandling: 'merge',
        queryParams: {lessonId},
      });
    }
  }

  getLessonTypeUrl(moduleIndex: number, lessonId: number) {
    const currentLesson = this.courseInfo?.modules[this.currentModuleIndex!].lessons.find(e => e.id === lessonId);
    if(currentLesson) {
      switch(currentLesson.type) {
        case "Text":
          return '/edit-course/edit-text-lesson';
        case "Video":
          return '/edit-course/edit-video-lesson';
        case "Test":
          return '/edit-course/edit-test-lesson';
        case "Literature":
          return '/edit-course/edit-add-material-lesson';
        case "Presentation":
          return '/edit-course/edit-presentation-lesson';
      }
    }
    return null;
  }
}
