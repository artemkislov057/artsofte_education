import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModuleItemComponent } from './components/module-item/module-item.component';
import { BrowserModule } from '@angular/platform-browser';
import { CourseMenuComponent } from './course-menu.component';

@NgModule({
  declarations: [
    CourseMenuComponent,
    ModuleItemComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule
  ],
  exports: [CourseMenuComponent],
  bootstrap: [ModuleItemComponent]
})
export class CourseMenuModule { }
