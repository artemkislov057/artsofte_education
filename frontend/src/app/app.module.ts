import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { CourseMenuModule } from './components/course-menu/course-menu.module';
import { StartPageModule } from './pages/start-page/start-page.module';
import { CreatePageModule } from './pages/modules/create-page-module/create-page-module.module';
import { CourseContentPageModule } from './pages/course-content-page/course-content-page.module';
import { EditCoursePageModule } from './pages/edit-course-page/edit-course-page.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CourseMenuModule,
    StartPageModule,
    CreatePageModule,
    CourseContentPageModule,
    EditCoursePageModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
