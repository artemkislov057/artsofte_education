import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
          }
        ]
      },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class EditCoursePageRoutingModule { }
