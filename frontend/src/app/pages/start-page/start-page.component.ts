import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { SetCourseId } from 'src/app/store/actions/course-id.action';
import { AppState } from 'src/app/store/states/app.state';
import { CourseType } from 'src/typings/api/courseType';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.scss']
})
export class StartPageComponent implements OnInit {
  courses: CourseType[] = [];

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) { }

  ngOnInit(): void {
    this.getCourses();
  }

  async getCourses() {
    const response = await fetch(`https://localhost:5001/api/courses`, {
      credentials: 'include',
    })
    const data = await response.json() as CourseType[];
    this.courses = data;
  }

  onClickCourse(courseId: string): void {
    this._store.dispatch(new SetCourseId(courseId));
    this.router.navigate(['/course-content'], {queryParams: { courseId }});
  }
}
