import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateContainerComponent } from './components/create-container/create-container.component';
import { LessonTypeComponent } from './components/lesson-type/lesson-type.component';
import { BottomEditContainerComponent } from './components/bottom-edit-container/bottom-edit-container.component';
import { LessonNameContainerComponent } from './components/lesson-name-container/lesson-name-container.component';
import { HeaderComponent } from './components/header/header.component';
import { TopToolarContainerComponent } from './components/top-toolar-container/top-toolar-container.component';
import { CourseMenuModule } from './components/course-menu/course-menu.module';
import { CourseslistModule } from './components/coursesList/courseslist.module';
import { StartPageModule } from './pages/start-page/start-page.module';
import { StartPageComponent } from './pages/start-page/start-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CreateContainerComponent,
    TopToolarContainerComponent,
    LessonTypeComponent,
    BottomEditContainerComponent,
    LessonNameContainerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CourseslistModule,
    CourseMenuModule,
    StartPageModule
  ],
  providers: [],
  bootstrap: [AppComponent, HeaderComponent, CourseMenuModule],
})
export class AppModule { }
