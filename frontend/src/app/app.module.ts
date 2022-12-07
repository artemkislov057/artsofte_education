import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { CourseslistModule } from './coursesList/courseslist.module';
import { CourseMenuModule } from './course-menu/course-menu.module';
import { CreateContainerComponent } from './create-container/create-container.component';
import { TopToolarContainerComponent } from './top-toolar-container/top-toolar-container.component';
import { LessonTypeComponent } from './lesson-type/lesson-type.component';
import { CoursePreviewContainerComponent } from './course-preview-container/course-preview-container.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CreateContainerComponent,
    TopToolarContainerComponent,
    LessonTypeComponent,
    CoursePreviewContainerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CourseslistModule,
    CourseMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent, HeaderComponent, CourseMenuModule],
})
export class AppModule { }
