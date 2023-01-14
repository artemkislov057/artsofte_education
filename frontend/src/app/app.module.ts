import { NgDompurifySanitizer } from "@tinkoff/ng-dompurify";
import { TuiRootModule, TuiDialogModule, TuiAlertModule, TUI_SANITIZER, TuiButtonModule } from "@taiga-ui/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
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
import { EditPresentationLessonPageComponent } from './pages/edit-presentation-lesson-page/edit-presentation-lesson-page.component';
import { AppService } from './app.service';
import { StoreModule } from '@ngrx/store';
import { appReducer } from './store/reducers/app.reducer';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { environment } from 'src/environments/environment';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    CourseMenuModule,
    StartPageModule,
    CreatePageModule,
    CourseContentPageModule,
    EditCoursePageModule,
    StoreModule.forRoot(appReducer),
    StoreRouterConnectingModule.forRoot({ stateKey: 'router' }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    AppRoutingModule,
    BrowserAnimationsModule,
    TuiRootModule,
    TuiDialogModule,
    TuiAlertModule,
    TuiButtonModule
  ],
  providers: [AppService, { provide: TUI_SANITIZER, useClass: NgDompurifySanitizer }],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor() {

  }


}
