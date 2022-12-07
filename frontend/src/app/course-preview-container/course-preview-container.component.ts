import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-course-preview-container',
  templateUrl: './course-preview-container.component.html',
  styleUrls: ['./course-preview-container.component.scss']
})
export class CoursePreviewContainerComponent implements OnInit {
  @Input() title: string = '';
  @Input() caption: string = '';
  @Input() srcCourseImage: string = '';
  @Input() theme: 'light' | 'dark' = 'light';
  @Input() backgroundColor: string = '#FFFFFF';

  constructor() { }

  ngOnInit(): void {
  }

}
