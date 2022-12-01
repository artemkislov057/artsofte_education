import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { CourseslistModule } from './coursesList/courseslist.module';
import { CourseMenuModule } from './course-menu/course-menu.module';
import { ModuleItemComponent } from './course-menu/components/module-item/module-item.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CourseslistModule,
    CourseMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent, HeaderComponent, CourseMenuModule]
})
export class AppModule { }
