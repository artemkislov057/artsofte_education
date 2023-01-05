import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AnswerOption, QuestionType } from 'src/typings/test';

@Component({
  selector: 'app-answer-option',
  templateUrl: './answer-option.component.html',
  styleUrls: ['./answer-option.component.scss']
})
export class AnswerOptionComponent implements OnInit {
  @Input() questionIndex: number = -1;
  @Input() type: QuestionType = 'radio';
  @Input() optionData: AnswerOption = {
    isCorrect: false,
    value: '',
  };
  @Input() id: number = -1;
  @Input() isDisabled: boolean = false;
  @Input() placeholder: string = 'Введите вариант ответа...';
  @Output() selectCorrectOption = new EventEmitter<boolean>();
  @Output() changeValueOption = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  onSelectCorrectOption(event: HTMLInputElement) {
    this.selectCorrectOption.emit(event.checked);
  }

  onChangeValueOption() {
    this.changeValueOption.emit(this.optionData.value);
  }

}
