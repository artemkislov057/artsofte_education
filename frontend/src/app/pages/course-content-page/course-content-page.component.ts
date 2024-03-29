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

  async ngOnInit(): Promise<void> {
    this.activeRouter.queryParamMap.subscribe((param) => {
      const courseId = param.get('courseId');
      if (courseId) {
        this.currentCourseId = courseId;
      } else {
        alert('Что то не так с ids');
      }
    })
    await this.getCourseInfo();
  }

  async getCourseInfo() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}`, {
      credentials: 'include',
    })
    const data = await response.json() as CourseType;
    this.courseInfo = data;
  }

  onClickModule(moduleId: string) {
    const moduleIndex = this.courseInfo.modules.findIndex(({ id }) => id === moduleId);
    const lessonData = this.courseInfo?.modules[moduleIndex].lessons;
    const lessonId = lessonData[0]?.id || null
    const type = lessonData[0]?.type || null;
    console.log(moduleIndex, lessonId, type)
    if (lessonId !== null) {
      const editUrlPage = this.getLessonTypeUrl(moduleIndex, lessonId)
      this.router.navigate([editUrlPage], {
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

  async onClickLesson({ moduleId, lessonId }: { moduleId: string, lessonId: number }) {
    const moduleIndex = this.courseInfo.modules.findIndex(({ id }) => id === moduleId);
    const editPageUrl = this.getLessonTypeUrl(moduleIndex, lessonId);
    console.log(moduleId, lessonId, editPageUrl)
    if (editPageUrl) {
      await this.router.navigate([editPageUrl], {
        queryParamsHandling: 'merge',
        queryParams: {
          moduleId,
          lessonId,
        },
      });
    }
  }

  async onDeleteModule(moduleId: string) {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${moduleId}`, {
      method: 'DELETE',
      credentials: 'include',
    });
    if (response.ok) {
      console.log('module deleted');
      await this.getCourseInfo();
    } else {
      console.log('module not delete')
    }
  }

  getLessonTypeUrl(moduleIndex: number, lessonId: number) {
    const currentLesson = this.courseInfo?.modules[moduleIndex].lessons.find(e => e.id === lessonId);
    if (currentLesson) {
      switch (currentLesson.type) {
        case "Text":
          return '/edit-course/edit-text-lesson';
        case "Video":
          return '/edit-course/edit-video-lesson';
        case "Test":
          return '/edit-course/edit-test-lesson';
        case "Literature":
          return '/edit-course/edit-add-material-lesson';
        case "Presentation":
          return '/edit-course/edit-presentation-lesson';
      }
    }
    return null;
  }
}
