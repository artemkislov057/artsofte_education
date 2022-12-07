import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseContentPageComponent } from './pages/course-content-page/course-content-page.component';
import { CreateModulePageComponent } from './pages/create-module-page/create-module-page.component';
import { CreatePageComponent } from './pages/create-page/create-page.component';
import { EditCoursePageComponent } from './pages/edit-course-page/edit-course-page.component';
import { StartPageComponent } from './pages/start-page/start-page.component';

const routes: Routes = [
  {path: '', component: StartPageComponent,},
  {path: 'create-course', component: CreatePageComponent,},
  {path: 'create-module', component: CreateModulePageComponent,},
  {path: 'course-content', component: CourseContentPageComponent,},
  {path: 'edit-course', component: EditCoursePageComponent,},
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
