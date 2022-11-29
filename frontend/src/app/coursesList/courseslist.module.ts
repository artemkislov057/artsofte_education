import { NgModule } from '@angular/core';
import { CourseslistComponent } from './courseslist.component';
import { CourseModule } from './components/course/course.module';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
    CourseslistComponent,
  ],
  imports: [BrowserModule, CourseModule],
  providers: [],
  bootstrap: [CourseslistComponent],
  exports: [CourseslistComponent]
})
export class CourseslistModule { }
