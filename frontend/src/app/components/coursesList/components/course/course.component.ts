import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Module } from 'src/typings/api/courseType';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  @Input() currentModule: Module = {
    description: '',
    id: '',
    lessons: [],
    name: ''
  };
  @Output() onClickModuleOut = new EventEmitter<string>();
  @Output() onClickLessonOut = new EventEmitter<{ moduleId: string; lessonId: number; }>();
  @Output() deleteModule = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onClickModule(moduleId: string) {
    this.onClickModuleOut.emit(moduleId);
  }

  onClickLesson(moduleId: string, lessonId: number) {
    this.onClickLessonOut.emit({ moduleId, lessonId })
  }

  onDeleteModule() {
    this.deleteModule.emit();
  }
}
