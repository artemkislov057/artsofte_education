import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditAdditionalMaterialPageComponent } from '../edit-additional-material-page/edit-additional-material-page.component';
import { EditPresentationLessonPageComponent } from '../edit-presentation-lesson-page/edit-presentation-lesson-page.component';
import { EditTestLessonPageComponent } from '../edit-test-lesson-page/edit-test-lesson-page.component';
import { EditTextLessonPageComponent } from '../edit-text-lesson-page/edit-text-lesson-page.component';
import { EditVideoLessonPageComponent } from '../edit-video-lesson-page/edit-video-lesson-page.component';
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
          {
            path: 'edit-add-material-lesson',
            component: EditAdditionalMaterialPageComponent,
          },
          {
            path: 'edit-video-lesson',
            component: EditVideoLessonPageComponent,
          },
          {
            path: 'edit-presentation-lesson',
            component: EditPresentationLessonPageComponent,
          },
        ]
      },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class EditCoursePageRoutingModule { }
