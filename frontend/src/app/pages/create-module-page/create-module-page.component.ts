import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { AppService } from 'src/app/app.service';
import { CourseIdSelector } from 'src/app/store/selectors/course-id.selector';
import { AppState } from 'src/app/store/states/app.state';
import { Module } from 'src/typings/api/courseType';

@Component({
  selector: 'app-create-module-page',
  templateUrl: './create-module-page.component.html',
  styleUrls: ['./create-module-page.component.scss']
})
export class CreateModulePageComponent implements OnInit {

  constructor(private router: Router, private appService: AppService, private _store: Store<AppState>) {  }

  ngOnInit(): void {
    let a = this._store.pipe(select(CourseIdSelector))
    a.subscribe(s => console.log(s))
  }

  async createModule(moduleName: string) {
    const courseId = this.appService.getCurrentCourseId();
    const response = await fetch(`https://localhost:5001/api/courses/${courseId}/modules`, {
      method: "POST",
      body: JSON.stringify({
        "name": moduleName,
        "description": "why?"
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    const data = await response.json() as Module;
    this.appService.setcurrentModuleId(data.id);
  }

  async onClickCreate(name: string) {
    if(name) {
      await this.createModule(name);
      this.router.navigateByUrl('/edit-course/select-lesson-type');
    }
  }
}
