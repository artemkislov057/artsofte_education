import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BottomEditContainerComponent } from './components/bottom-edit-container/bottom-edit-container.component';
import { LessonNameContainerComponent } from './components/lesson-name-container/lesson-name-container.component';
import { HeaderComponent } from './components/header/header.component';
import { CourseMenuModule } from './components/course-menu/course-menu.module';
import { StartPageModule } from './pages/start-page/start-page.module';
import { CreatePageModule } from './pages/modules/create-page-module/create-page-module.module';
import { CourseContentPageModule } from './pages/course-content-page/course-content-page.module';
import { EditCoursePageModule } from './pages/edit-course-page/edit-course-page.module';
import { TextEditorComponent } from './components/text-editor/text-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BottomEditContainerComponent,
    LessonNameContainerComponent,
    TextEditorComponent,
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
