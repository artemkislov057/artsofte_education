import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lesson-type-page',
  templateUrl: './lesson-type-page.component.html',
  styleUrls: ['./lesson-type-page.component.scss']
})
export class LessonTypePageComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToCreateTextLesson(): void {
    this.router.navigateByUrl('/edit-course/edit-text-lesson');
  }

  navigateToCreateTestLesson(): void {
    this.router.navigateByUrl('/edit-course/edit-test-lesson');
  }

}
