import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

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

  @Output() onClickPreview = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onClick(): void {
    this.onClickPreview.emit();
  }

}
