import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CoursePreviewContainerComponent } from 'src/app/components/course-preview-container/course-preview-container.component';
import { StartPageComponent } from './start-page.component';


@NgModule({
  declarations: [
    StartPageComponent,
    CoursePreviewContainerComponent
  ],
  imports: [
    BrowserModule,
  ],
  exports: [StartPageComponent],
  providers: [],
  bootstrap: [],
})
export class StartPageModule { }
