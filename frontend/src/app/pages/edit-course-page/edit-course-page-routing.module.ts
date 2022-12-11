import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditTestLessonPageComponent } from '../edit-test-lesson-page/edit-test-lesson-page.component';
import { EditTextLessonPageComponent } from '../edit-text-lesson-page/edit-text-lesson-page.component';
import { LessonTypePageComponent } from '../lesson-type-page/lesson-type-page.component';
import { EditCoursePageComponent } from './edit-course-page.component';

const routes: Routes = [
    {
        path: 'edit-course', 
        component: EditCoursePageComponent,
        children: [
          {
            path: 'select-lesson-type',
            component: LessonTypePageComponent,
          },
          {
            path: 'edit-text-lesson',
            component: EditTextLessonPageComponent,
          },
          {
            path: 'edit-test-lesson',
            component: EditTestLessonPageComponent,
          },
        ]
      },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class EditCoursePageRoutingModule { }
