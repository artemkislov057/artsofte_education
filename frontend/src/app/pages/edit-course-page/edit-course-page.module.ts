import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CourseMenuModule } from 'src/app/components/course-menu/course-menu.module';
import { LessonTypeComponent } from 'src/app/components/lesson-type/lesson-type.component';
import { TopToolarContainerComponent } from 'src/app/components/top-toolar-container/top-toolar-container.component';
import { LessonTypePageComponent } from '../lesson-type-page/lesson-type-page.component';
import { EditCoursePageRoutingModule } from './edit-course-page-routing.module';
import { EditCoursePageComponent } from './edit-course-page.component';

@NgModule({
  declarations: [
    EditCoursePageComponent,
    LessonTypeComponent,
    TopToolarContainerComponent,
    LessonTypePageComponent
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
