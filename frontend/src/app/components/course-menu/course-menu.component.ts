import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Module } from 'src/typings/api/courseType';

@Component({
  selector: 'app-course-menu',
  templateUrl: './course-menu.component.html',
  styleUrls: ['./course-menu.component.scss']
})
export class CourseMenuComponent implements OnInit {
  @Input() menuItems: Array<Module> = [];
  @Output() createModule = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onClickCreateModule() {
    this.createModule.emit();
  }

}
