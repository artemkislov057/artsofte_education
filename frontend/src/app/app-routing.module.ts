import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateModulePageComponent } from './pages/create-module-page/create-module-page.component';
import { CreatePageComponent } from './pages/create-page/create-page.component';
import { StartPageComponent } from './pages/start-page/start-page.component';

const routes: Routes = [
  {path: '', component: StartPageComponent,},
  {path: 'create-course', component: CreatePageComponent,},
  {path: 'create-module', component: CreateModulePageComponent,},
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
