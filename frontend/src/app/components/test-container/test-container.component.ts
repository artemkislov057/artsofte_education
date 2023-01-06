import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AnswerOption, QuestionType } from 'src/typings/test';

@Component({
  selector: 'app-test-container',
  templateUrl: './test-container.component.html',
  styleUrls: ['./test-container.component.scss']
})
export class TestContainerComponent implements OnInit {
  @Input() questionIndex: number | null = null;
  @Input() typeAnswers: QuestionType = 'RadioButton';
  @Input() options: AnswerOption[] = [];
  @Output() changeQuestionType = new EventEmitter<{questionIndex: number, questionType: QuestionType}>();
  @Output() addAnswerOption = new EventEmitter<number>();
  @Output() selectCorrectOption = new EventEmitter<{ questionIndex: number, optionIndex: number, isChecked: boolean }>();
  @Output() changeInputValueOption = new EventEmitter<{ questionIndex: number, optionIndex: number, value: string }>();
  @Output() deleteAnswerOption = new EventEmitter<{ questionIndex: number, optionIndex: number }>();


  constructor() { }

  ngOnInit(): void {
  }

  onChangeQustionType(questType: QuestionType) {
    if(this.questionIndex !== null) {
      this.changeQuestionType.emit({
        questionIndex: this.questionIndex,
        questionType: questType
      })
    }
  }

  onAddAnswerOption() {
    if(this.questionIndex !== null) {
      this.addAnswerOption.emit(this.questionIndex);
    }
  }

  onSelectCorrectOption(optionIndex: number, isChecked: boolean) {
    if(this.questionIndex !== null) {
      this.selectCorrectOption.emit({
        optionIndex,
        questionIndex: this.questionIndex,
        isChecked,
      })
    }
  }

  onChangeValueInputOption(optionIndex: number, value: string) {
    if(this.questionIndex !== null) {
      this.changeInputValueOption.emit({
        optionIndex,
        questionIndex: this.questionIndex,
        value,
      })
    }
  }

  onDeleteAnswerOption(optionIndex: number) {
    if(this.questionIndex !== null) {
      this.deleteAnswerOption.emit({
        optionIndex,
        questionIndex: this.questionIndex,
      })
    }
  }
}
