import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-lesson-name-container',
  templateUrl: './lesson-name-container.component.html',
  styleUrls: ['./lesson-name-container.component.scss']
})
export class LessonNameContainerComponent implements OnInit {
  @Input() titleName: string | null = 'Название урока';
  @Output() changeLessonName = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  onChangeName(name: string) {
    this.changeLessonName.emit(name);
  }

}
