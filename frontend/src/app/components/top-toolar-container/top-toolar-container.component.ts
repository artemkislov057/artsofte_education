import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
    if(this.lessons[0]?.id as number) {
      this.isActiveId = this.lessons[0]?.id;
    }
  }

  ngOnInit(): void {
    console.log(this.lessons)
  }

  onChangeLesson(lessonId: number) {
    this.isActiveId = lessonId;
    this.onClickLesson.emit(lessonId);
  }

  onClickCreate() {
    this.onClickCreateLesson.emit();
  }
}
