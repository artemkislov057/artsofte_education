import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TuiButtonModule } from '@taiga-ui/core';
import { PresentationTopToolbarComponent } from '../presentation-top-toolbar/presentation-top-toolbar.component';
import { PresentationContainerComponent } from './presentation-container.component';

@NgModule({
  declarations: [
    PresentationContainerComponent,
    PresentationTopToolbarComponent,
  ],
  imports: [BrowserModule, TuiButtonModule],
  providers: [],
  bootstrap: [],
  exports: [PresentationContainerComponent]
})
export class PresentationContainerModule { }
