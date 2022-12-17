import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CourseType } from 'src/typings/api/courseType';

@Component({
  selector: 'app-create-page',
  templateUrl: './create-page.component.html',
  styleUrls: ['./create-page.component.scss']
})
export class CreatePageComponent implements OnInit {
  courseId: string = '';
  moduleId: string = '';

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  async createCourse(courseName: string) {
    const response = await fetch('https://localhost:5001/api/courses', {
      method: "POST",
      body: JSON.stringify({
        "name": courseName,
        "description": "why?"
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    const data = await response.json() as CourseType;
    console.log(data)
  }

  async onClickCreate(name: string) {
    if(name) {
      await this.createCourse(name);
      this.router.navigateByUrl('/create-module');
    }
  }

}
