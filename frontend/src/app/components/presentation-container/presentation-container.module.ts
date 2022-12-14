import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PresentationTopToolbarComponent } from '../presentation-top-toolbar/presentation-top-toolbar.component';
import { PresentationContainerComponent } from './presentation-container.component';

@NgModule({
  declarations: [
    PresentationContainerComponent,
    PresentationTopToolbarComponent,
  ],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [],
  exports: [PresentationContainerComponent]
})
export class PresentationContainerModule { }
