import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CourseType, Module } from 'src/typings/api/courseType';

@Component({
  selector: 'app-course-menu',
  templateUrl: './course-menu.component.html',
  styleUrls: ['./course-menu.component.scss']
})
export class CourseMenuComponent implements OnInit {
  @Input() courseInfo!: CourseType;
  @Output() createModule = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onClickCreateModule() {
    this.createModule.emit();
  }

}
