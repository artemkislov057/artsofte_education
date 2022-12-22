import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store/states/app.state';

@Component({
  selector: 'app-lesson-type-page',
  templateUrl: './lesson-type-page.component.html',
  styleUrls: ['./lesson-type-page.component.scss']
})
export class LessonTypePageComponent implements OnInit {
  currentCourseId: string = '';
  currentModuleId: string = '';

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) { }

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
  }


  navigateToCreateTextLesson(): void {
    this.router.navigate(['/edit-course/edit-text-lesson'], {queryParamsHandling: 'preserve'});
  }

  navigateToCreateTestLesson(): void {
    this.router.navigateByUrl('/edit-course/edit-test-lesson');
  }

  navigateToCreateAdditionalMaterialLesson(): void {
    this.router.navigateByUrl('/edit-course/edit-add-material-lesson');
  }

  navigateToCreateVideoLesson(): void {
    this.router.navigateByUrl('/edit-course/edit-video-lesson');
  }

  navigateToCreatePresentationLesson(): void {
    this.router.navigateByUrl('/edit-course/edit-presentation-lesson');
  }
}
