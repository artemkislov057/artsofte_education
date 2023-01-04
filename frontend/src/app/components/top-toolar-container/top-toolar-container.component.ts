import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { Lesson } from 'src/typings/api/courseType';

@Component({
  selector: 'app-top-toolar-container',
  templateUrl: './top-toolar-container.component.html',
  styleUrls: ['./top-toolar-container.component.scss']
})
export class TopToolarContainerComponent implements OnInit {
  @Input() moduleId: string | null = null;
  @Input() lessons: Array<Lesson> | null = null; // массив id созданных уроков - мб сохранить это все в хранилище и просто потом обращаться, чтобы не срать запросами постоянно
  @Output() onClickLesson = new EventEmitter<number>(); // ф-ия для перехода на определенный урок с аргументом - id урока
  @Output() onClickCreateLesson = new EventEmitter(); // ф-ия для перехода на экран создания нового урока
  isActiveId: number | null = null; // мб сделать Input()

  constructor() { }

  ngOnChanges(changes: any) {
    if(!this.lessons) {
      return;
    }
    const changeModule = changes.moduleId;
    if(changeModule && changeModule.previousValue !== changeModule.currentValue) {
      this.isActiveId = this.lessons[0].id;
      return;
    }
    const lessons = changes.lessons;
    
    const prev = lessons.previousValue;
    const curr = lessons.currentValue;
    if(prev === null) {
      console.log('Prev нет', prev)
      this.isActiveId = this.lessons[0].id;
      return;
    }
    if(prev.length + 1 === curr.length){
      console.log('добавился новый урок в модуль')
      this.isActiveId = this.lessons[this.lessons.length - 1].id;
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
