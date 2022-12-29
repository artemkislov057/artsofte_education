import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store/states/app.state';
import { CourseType } from 'src/typings/api/courseType';

const initCourseInfo = {
  description: '',
  id: '',
  modules: [],
  name: '',
}

@Component({
  selector: 'app-course-content-page',
  templateUrl: './course-content-page.component.html',
  styleUrls: ['./course-content-page.component.scss']
})
export class CourseContentPageComponent implements OnInit {
  courseInfo: CourseType = initCourseInfo;
  currentCourseId: string = '';

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) { }

  ngOnInit(): void {
    this.activeRouter.queryParamMap.subscribe((param) => {
      const courseId = param.get('courseId');
      if(courseId) {
        this.currentCourseId = courseId;
      } else {
        alert('Что то не так с ids');
      }
   })
   this.getCourseInfo();
  }

  async getCourseInfo() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}`, {
      credentials: 'include',
    })
    const data = await response.json() as CourseType;
    this.courseInfo = data;
  }

  onClickModule(moduleId: string) {
    const moduleIndex = this.courseInfo.modules.findIndex(({id}) => id === moduleId);
    const lessonData = this.courseInfo?.modules[moduleIndex].lessons;
    const lessonId = lessonData[0]?.id || null
    const type = lessonData[0]?.type || null;
    console.log(moduleIndex, lessonId, type)
    if(lessonId !== null && type === 'Text') {
      this.router.navigate(['/edit-course/edit-text-lesson'], {
        queryParams: {
          moduleId,
          lessonId,
        },
        queryParamsHandling: 'merge',
      });
    } else {
      this.router.navigate(['/edit-course/select-lesson-type'], {
        queryParams: {
          moduleId
        },
        queryParamsHandling: 'merge',
      });
    }
  }

  onClickLesson({moduleId, lessonId}: {moduleId: string, lessonId: number}) {
    // добавить обработку для перехода не только в текстовые уроки
    this.router.navigate(['/edit-course/edit-text-lesson'], {
      queryParams: {
        moduleId,
        lessonId,
      },
      queryParamsHandling: 'merge',
    });
  }

}
