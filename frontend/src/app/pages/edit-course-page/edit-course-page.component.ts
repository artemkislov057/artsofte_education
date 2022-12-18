import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppService } from 'src/app/app.service';
import { AppState } from 'src/app/store/states/app.state';
import { CourseType, Module } from 'src/typings/api/courseType';
import { CourseMenuItem } from 'src/typings/courseMenuItemType';

@Component({
  selector: 'app-edit-course-page',
  templateUrl: './edit-course-page.component.html',
  styleUrls: ['./edit-course-page.component.scss']
})
export class EditCoursePageComponent implements OnInit {
  courseInfo!: CourseType;
  currentCourseId: string = '';
  currentModuleId: string = '';

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
   this.getModulesList();
  }

  async getModulesList() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}`, {
      credentials: 'include',
    })
    const data = await response.json() as CourseType;
    this.courseInfo = data;
    console.log(data)
  }

  createModule() {
    // this.router.navigateByUrl('/create-module');
    this.router.navigate(['/create-module'], {queryParams: {courseId: this.currentCourseId}});
  }
}
