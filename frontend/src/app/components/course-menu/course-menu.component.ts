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
  @Output() createModule = new EventEmitter();
  @Output() changeModule = new EventEmitter<ModuleInfo>();
  activeModuleIndex: number = 0;

  constructor() { }

  ngOnInit(): void {
  }

  onClickCreateModule() {
    this.createModule.emit();
  }

  onChangeModule(moduleInfo: ModuleInfo) {
    this.activeModuleIndex = moduleInfo.moduleIndex;
    this.changeModule.emit(moduleInfo);
  }

}
