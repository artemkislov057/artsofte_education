import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { AppService } from 'src/app/app.service';
import { SetCourseId } from 'src/app/store/actions/course-id.action';
import { CourseIdSelector } from 'src/app/store/selectors/course-id.selector';
import { AppState } from 'src/app/store/states/app.state';
import { CourseType } from 'src/typings/api/courseType';

@Component({
  selector: 'app-create-page',
  templateUrl: './create-page.component.html',
  styleUrls: ['./create-page.component.scss']
})
export class CreatePageComponent implements OnInit {
  constructor(private router: Router, private _store: Store<AppState>) { }

  ngOnInit(): void {
  }

  async createCourse(courseName: string) {
    const response = await fetch('https://localhost:5001/api/courses', {
      method: "POST",
      body: JSON.stringify({
        "name": courseName,
        "description": "Курс для учеников ИРИТ-РТФ"
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    const data = await response.json() as CourseType;
    this._store.dispatch(new SetCourseId(data.id));
    return data.id
  }

  async onClickCreate(name: string) {
    if(name) {
      const currentCourseId = await this.createCourse(name);
      // this.router.navigateByUrl('/create-module');
      this.router.navigate(['/create-module'], {queryParams: {courseId: currentCourseId}});
    }
  }

}
