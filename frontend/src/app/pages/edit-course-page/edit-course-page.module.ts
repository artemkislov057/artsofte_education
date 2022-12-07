import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CourseMenuModule } from 'src/app/components/course-menu/course-menu.module';
import { LessonTypeComponent } from 'src/app/components/lesson-type/lesson-type.component';
import { TopToolarContainerComponent } from 'src/app/components/top-toolar-container/top-toolar-container.component';
import { EditCoursePageComponent } from './edit-course-page.component';

@NgModule({
  declarations: [
    EditCoursePageComponent,
    LessonTypeComponent,
    TopToolarContainerComponent
  ],
  imports: [
    BrowserModule,
    CourseMenuModule
  ],
  exports: [EditCoursePageComponent],
  providers: [],
  bootstrap: [],
})
export class EditCoursePageModule { }
