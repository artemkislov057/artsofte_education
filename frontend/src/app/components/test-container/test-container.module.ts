import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AnswerOptionComponent } from '../answer-option/answer-option.component';
import { TestTypeButtonsComponent } from '../test-type-buttons/test-type-buttons.component';
import { TestContainerComponent } from './test-container.component';

@NgModule({
  declarations: [
    TestContainerComponent,
    AnswerOptionComponent,
    TestTypeButtonsComponent,

  ],
  imports: [BrowserModule, FormsModule],
  providers: [],
  bootstrap: [TestContainerComponent],
  exports: [TestContainerComponent]
})
export class TestContainerModule { }
