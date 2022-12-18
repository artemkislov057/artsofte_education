import { Component, Input, OnInit } from '@angular/core';
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
  }

  constructor() { }

  ngOnInit(): void {
  }

}
