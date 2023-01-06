import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { Lesson } from 'src/typings/api/courseType';

@Component({
  selector: 'app-top-toolar-container',
  templateUrl: './top-toolar-container.component.html',
  styleUrls: ['./top-toolar-container.component.scss']
})
export class TopToolarContainerComponent implements OnInit {
  @Input() moduleId: string | null = null;
  @Input() lessons: Array<Lesson> | null = null;
  @Input() activeLessonId: number | null = null;
  @Output() onClickLesson = new EventEmitter<number>();
  @Output() onClickCreateLesson = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onChangeLesson(lessonId: number) {
    console.log(lessonId, this.activeLessonId)
    this.onClickLesson.emit(lessonId);
  }

  onClickCreate() {
    this.onClickCreateLesson.emit();
  }
}
