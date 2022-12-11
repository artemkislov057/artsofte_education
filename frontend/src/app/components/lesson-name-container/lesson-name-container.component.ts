import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-lesson-name-container',
  templateUrl: './lesson-name-container.component.html',
  styleUrls: ['./lesson-name-container.component.scss']
})
export class LessonNameContainerComponent implements OnInit {
  @Input() titleName: string = 'Название урока';

  constructor() { }

  ngOnInit(): void {
  }

}
