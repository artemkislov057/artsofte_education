import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() onClickCreateCourse = new EventEmitter();
  @Output() onClickHome = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  createCourse(): void {
    this.onClickCreateCourse.emit();
  }

  toHome(): void {
    this.onClickHome.emit();
  }

}
