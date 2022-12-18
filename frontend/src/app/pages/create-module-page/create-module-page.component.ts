import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { AppService } from 'src/app/app.service';
import { SetModuleId } from 'src/app/store/actions/module-id.action';
import { CourseIdSelector } from 'src/app/store/selectors/course-id.selector';
import { AppState } from 'src/app/store/states/app.state';
import { Module } from 'src/typings/api/courseType';

@Component({
  selector: 'app-create-module-page',
  templateUrl: './create-module-page.component.html',
  styleUrls: ['./create-module-page.component.scss']
})
export class CreateModulePageComponent implements OnInit {
  currentCourseId: string = '';

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) {  }

  ngOnInit(): void {
    this._store.pipe(select(CourseIdSelector)).subscribe(id => this.currentCourseId = id)
  }

  async createModule(moduleName: string) {
    if(!this.currentCourseId) {
      this.activeRouter.queryParamMap.subscribe((param) => {
         const id = param.get('courseId');
         if(id) {
           this.currentCourseId = id;
         } else {
          alert('Что то пошло не так с courseId');
         }
      })
    }
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules`, {
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
    this._store.dispatch(new SetModuleId(data.id));
    return data.id;
  }

  async onClickCreate(name: string) {
    if(name) {
      const moduleId = await this.createModule(name);
      // this.router.navigateByUrl('/edit-course/select-lesson-type');
      this.router.navigate(['/edit-course/select-lesson-type'], {
        queryParamsHandling: 'merge',
        queryParams: {
          moduleId: moduleId,
        }
      });
    }
  }
}
