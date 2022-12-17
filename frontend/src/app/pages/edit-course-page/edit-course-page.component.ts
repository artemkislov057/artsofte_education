import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from 'src/app/app.service';
import { CourseType, Module } from 'src/typings/api/courseType';
import { CourseMenuItem } from 'src/typings/courseMenuItemType';

@Component({
  selector: 'app-edit-course-page',
  templateUrl: './edit-course-page.component.html',
  styleUrls: ['./edit-course-page.component.scss']
})
export class EditCoursePageComponent implements OnInit {
  menuItems: Array<Module> = [];

  constructor(private apiService: AppService, private router: Router) { 
    this.getModulesList();
  }

  ngOnInit(): void {
  }

  async getModulesList() {
    const courseId = this.apiService.getCurrentCourseId();
    const response = await fetch(`https://localhost:5001/api/courses/${courseId}/modules`, {
      credentials: 'include',
    })
    const data = await response.json() as Array<Module>;
    console.log(data)
    this.menuItems = data;
  }

  createModule() {
    this.router.navigateByUrl('/create-module');
  }
}
