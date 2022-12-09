import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HeaderCourseComponent } from './components/header-course/header-course.component';
import { ItemCourseComponent } from './components/item-course/item-course.component';
import { CourseComponent } from './course.component';


@NgModule({
  declarations: [
    CourseComponent,
    ItemCourseComponent,
    HeaderCourseComponent,
  ],
  imports: [
    BrowserModule,
  ],
  providers: [],
  bootstrap: [],
  exports: [CourseComponent]
})
export class CourseModule { }
