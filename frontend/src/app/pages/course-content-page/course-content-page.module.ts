import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CourseslistModule } from 'src/app/components/coursesList/courseslist.module';
import { CourseContentPageComponent } from './course-content-page.component';

@NgModule({
  declarations: [
    CourseContentPageComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    CourseslistModule,
  ],
  exports: [CourseContentPageComponent],
  providers: [],
  bootstrap: [],
})
export class CourseContentPageModule { }
