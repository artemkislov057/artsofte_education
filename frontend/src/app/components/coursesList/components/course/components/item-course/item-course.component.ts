import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-item-course',
  templateUrl: './item-course.component.html',
  styleUrls: ['./item-course.component.scss']
})
export class ItemCourseComponent implements OnInit {
  @Input() title: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
