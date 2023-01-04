import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { Lesson } from 'src/typings/api/courseType';

@Component({
  selector: 'app-top-toolar-container',
  templateUrl: './top-toolar-container.component.html',
  styleUrls: ['./top-toolar-container.component.scss']
})
export class TopToolarContainerComponent implements OnInit {
  @Input() lessons: Array<Lesson> = []; // массив id созданных уроков - мб сохранить это все в хранилище и просто потом обращаться, чтобы не срать запросами постоянно
  @Output() onClickLesson = new EventEmitter<number>(); // ф-ия для перехода на определенный урок с аргументом - id урока
  @Output() onClickCreateLesson = new EventEmitter(); // ф-ия для перехода на экран создания нового урока
  isActiveId: number | null = null;

  constructor() { }

  ngOnChanges(changes: any) {
    const lessons = changes.lessons;
    if(lessons.previousValue.length !== lessons.currentValue.length) {
      this.isActiveId = this.lessons[0]?.id;
    }
    if(lessons.previousValue.length && lessons.currentValue.length) {
      const prev = lessons.previousValue;
      const curr = lessons.currentValue;
      if(prev[0]?.id === curr[0]?.id && prev.length + 1 === curr.length) {
        this.isActiveId = this.lessons[this.lessons.length - 1]?.id;
      }
    }
  }

  ngOnInit(): void {
  }

  onChangeLesson(lessonId: number) {
    this.isActiveId = lessonId;
    this.onClickLesson.emit(lessonId);
  }

  onClickCreate() {
    this.onClickCreateLesson.emit();
  }
}
