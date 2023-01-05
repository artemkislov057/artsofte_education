import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { QuestionType } from 'src/typings/test';

@Component({
  selector: 'app-test-type-buttons',
  templateUrl: './test-type-buttons.component.html',
  styleUrls: ['./test-type-buttons.component.scss']
})
export class TestTypeButtonsComponent implements OnInit {
  @Input() isActiveRadio: boolean = true;
  @Output() changeQuestionType = new EventEmitter<QuestionType>();

  constructor() { }

  ngOnInit(): void {
  }

  onChangeQuestionType(questionType: QuestionType) {
    this.changeQuestionType.emit(questionType);
  }

}
