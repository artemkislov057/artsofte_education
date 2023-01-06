import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CourseType, Module } from 'src/typings/api/courseType';
import { ModuleInfo } from 'src/typings/module';

@Component({
  selector: 'app-course-menu',
  templateUrl: './course-menu.component.html',
  styleUrls: ['./course-menu.component.scss']
})
export class CourseMenuComponent implements OnInit {
  @Input() courseInfo: CourseType | null = null;
  @Input() activeModuleIndex: number = 0;
  @Output() createModule = new EventEmitter();
  @Output() changeModule = new EventEmitter<ModuleInfo>();

  constructor() { }

  ngOnInit(): void {
  }

  onClickCreateModule() {
    this.createModule.emit();
  }

  onChangeModule(moduleInfo: ModuleInfo) {
    this.changeModule.emit(moduleInfo);
  }

}
