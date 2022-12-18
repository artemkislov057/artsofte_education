import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header-course',
  templateUrl: './header-course.component.html',
  styleUrls: ['./header-course.component.scss']
})
export class HeaderCourseComponent implements OnInit {
  @Input() title: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
