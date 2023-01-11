import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header-course',
  templateUrl: './header-course.component.html',
  styleUrls: ['./header-course.component.scss']
})
export class HeaderCourseComponent implements OnInit {
  @Input() title: string = '';
  @Output() remove = new EventEmitter();
  @Output() clickEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onRemoveButton() {
    this.remove.emit();
  }

  onClick() {
    this.clickEvent.emit();
  }

}
