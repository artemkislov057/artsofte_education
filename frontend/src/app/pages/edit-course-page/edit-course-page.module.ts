import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AdditionalMaterialContainerComponent } from 'src/app/components/additional-material-container/additional-material-container.component';
import { BottomEditContainerComponent } from 'src/app/components/bottom-edit-container/bottom-edit-container.component';
import { CourseMenuModule } from 'src/app/components/course-menu/course-menu.module';
import { LessonNameContainerComponent } from 'src/app/components/lesson-name-container/lesson-name-container.component';
import { LessonTypeComponent } from 'src/app/components/lesson-type/lesson-type.component';
import { PresentationContainerModule } from 'src/app/components/presentation-container/presentation-container.module';
import { TestContainerModule } from 'src/app/components/test-container/test-container.module';
import { TextEditorComponent } from 'src/app/components/text-editor/text-editor.component';
import { TopToolarContainerComponent } from 'src/app/components/top-toolar-container/top-toolar-container.component';
import { VideoContainerComponent } from 'src/app/components/video-container/video-container.component';
import { EditAdditionalMaterialPageComponent } from '../edit-additional-material-page/edit-additional-material-page.component';
import { EditPresentationLessonPageComponent } from '../edit-presentation-lesson-page/edit-presentation-lesson-page.component';
import { EditTestLessonPageComponent } from '../edit-test-lesson-page/edit-test-lesson-page.component';
import { EditTextLessonPageComponent } from '../edit-text-lesson-page/edit-text-lesson-page.component';
import { EditVideoLessonPageComponent } from '../edit-video-lesson-page/edit-video-lesson-page.component';
import { LessonTypePageComponent } from '../lesson-type-page/lesson-type-page.component';
import { EditCoursePageRoutingModule } from './edit-course-page-routing.module';
import { EditCoursePageComponent } from './edit-course-page.component';

@NgModule({
  declarations: [
    EditCoursePageComponent,
    LessonTypeComponent,
    TopToolarContainerComponent,
    LessonTypePageComponent,
    EditTextLessonPageComponent,
    TextEditorComponent,
    LessonNameContainerComponent,
    BottomEditContainerComponent,
    EditTestLessonPageComponent,
    AdditionalMaterialContainerComponent,
    EditAdditionalMaterialPageComponent,
    VideoContainerComponent,
    EditVideoLessonPageComponent,
    EditPresentationLessonPageComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    EditCoursePageRoutingModule,
    CourseMenuModule,
    TestContainerModule,
    PresentationContainerModule,
    FormsModule,
  ],
  exports: [EditCoursePageComponent],
  providers: [],
  bootstrap: [EditCoursePageComponent],
})
export class EditCoursePageModule { }
