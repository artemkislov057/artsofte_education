import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BottomEditContainerComponent } from 'src/app/components/bottom-edit-container/bottom-edit-container.component';
import { CourseMenuModule } from 'src/app/components/course-menu/course-menu.module';
import { LessonNameContainerComponent } from 'src/app/components/lesson-name-container/lesson-name-container.component';
import { LessonTypeComponent } from 'src/app/components/lesson-type/lesson-type.component';
import { TextEditorComponent } from 'src/app/components/text-editor/text-editor.component';
import { TopToolarContainerComponent } from 'src/app/components/top-toolar-container/top-toolar-container.component';
import { EditTextLessonPageComponent } from '../edit-text-lesson-page/edit-text-lesson-page.component';
import { LessonTypePageComponent } from '../lesson-type-page/lesson-type-page.component';
import { EditCoursePageRoutingModule } from './edit-course-page-routing.module';
import { EditCoursePageComponent } from './edit-course-page.component';

@NgModule({
  declarations: [
    EditCoursePageComponent,
    LessonTypeComponent,
    TopToolarContainerComponent,
    LessonTypePageComponent,
    EditTextLessonPageComponent,
    TextEditorComponent,
    LessonNameContainerComponent,
    BottomEditContainerComponent,
  ],
  imports: [
    BrowserModule,
    EditCoursePageRoutingModule,
    CourseMenuModule
  ],
  exports: [EditCoursePageComponent],
  providers: [],
  bootstrap: [EditCoursePageComponent],
})
export class EditCoursePageModule { }
