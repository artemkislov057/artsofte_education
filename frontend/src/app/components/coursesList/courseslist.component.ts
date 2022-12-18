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

  constructor() { }

  ngOnInit(): void {
  }

  onClickModule(moduleId: string) {
    this.onClickModuleOut.emit(moduleId);
  }

}
