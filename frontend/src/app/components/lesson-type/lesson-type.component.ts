import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LessonType } from 'typings/lessonType';

const typeData: {[key in LessonType]: {
  title: string;
  caption: string;
}} = {
  literature: {
    title: 'Литература',
    caption: 'Добавляйте ссылки на книги и источники  '
  },
  presentation: {
    title: 'Презентация',
    caption: 'Создавайте презентации и озвучивайте их '
  },
  test: {
    title: 'Тест',
    caption: 'Составляйте тесты для проверки знаний'
  },
  text: {
    title: 'Текст',
    caption: 'Добавляйте текст и изображения для ваших лекций'
  },
  video: {
    title: 'Видео',
    caption: 'Добавляйте уже готовые видео уроки'
  },
}

@Component({
  selector: 'app-lesson-type',
  templateUrl: './lesson-type.component.html',
  styleUrls: ['./lesson-type.component.scss']
})

export class LessonTypeComponent implements OnInit {
  @Input() type: LessonType = 'text';
  @Output() onSelectLessonType = new EventEmitter();

  typeData: { title: string; caption: string; };
  constructor() {
    this.typeData = typeData[this.type]
  }

  ngOnInit(): void {
    this.typeData = typeData[this.type]
  }

  onClick(): void {
    this.onSelectLessonType.emit();
  }

}
