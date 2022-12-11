import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-answer-option',
  templateUrl: './answer-option.component.html',
  styleUrls: ['./answer-option.component.scss']
})
export class AnswerOptionComponent implements OnInit {
  @Input() type: 'radio' | 'checkbox' = 'radio';

  constructor() { }

  ngOnInit(): void {
  }

}
