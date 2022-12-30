import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Module } from 'src/typings/api/courseType';

@Component({
  selector: 'app-courseslist',
  templateUrl: './courseslist.component.html',
  styleUrls: ['./courseslist.component.scss']
})
export class CourseslistComponent implements OnInit {
  @Input() modules: Module[] = [];
  @Output() onClickModuleOut = new EventEmitter<string>();
  @Output() onClickLessonOut = new EventEmitter<{moduleId: string; lessonId: number;}>();

  constructor() { }

  ngOnInit(): void {
  }

  onClickModule(moduleId: string) {
    this.onClickModuleOut.emit(moduleId);
  }

  onClickLesson({moduleId, lessonId}: {moduleId: string, lessonId: number}) {
    this.onClickLessonOut.emit({moduleId, lessonId})
  }
}
