import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CreateContainerComponent } from 'src/app/components/create-container/create-container.component';
import { CreateModulePageComponent } from '../../create-module-page/create-module-page.component';
import { CreatePageComponent } from '../../create-page/create-page.component';

@NgModule({
  declarations: [
    CreateContainerComponent,
    CreateModulePageComponent,
    CreatePageComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
  ],
  exports: [CreateContainerComponent, CreateModulePageComponent],
  providers: [],
  bootstrap: [],
})
export class CreatePageModule { }
