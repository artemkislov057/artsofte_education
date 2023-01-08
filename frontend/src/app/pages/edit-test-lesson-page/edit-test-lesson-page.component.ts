import { Component, OnInit, ViewChildren } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { OutputData } from '@editorjs/editorjs';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import { TextEditorComponent } from 'src/app/components/text-editor/text-editor.component';
import { AppState } from 'src/app/store/states/app.state';
import { Lesson, TestValue } from 'src/typings/api/courseType';
import { AnswerOption, QuestionType, TestQuestion } from 'src/typings/test';

const emptyOption: AnswerOption = {
  isCorrectAnswer: false,
  value: ''
}

@Component({
  selector: 'app-edit-test-lesson-page',
  templateUrl: './edit-test-lesson-page.component.html',
  styleUrls: ['./edit-test-lesson-page.component.scss']
})
export class EditTestLessonPageComponent implements OnInit {
  questions: TestQuestion[] = [];
  currentCourseId: string | null = null;
  currentModuleId: string | null = null;
  currentLessonId: number | null = null;
  lessonName: string | null = null;
  existsTextData: OutputData | null = null;
  isLessonExist: boolean = false;
  @ViewChildren(TextEditorComponent) textEditorComponent: TextEditorComponent[] = [];

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) { 
    this.onChangeUrl();
  }

  async onChangeUrl() {
    this.router.events.pipe(filter((e) => e instanceof NavigationEnd)).subscribe(async (e) => {
      if(this.currentCourseId && this.currentModuleId) {
        await this.getTestLessonData();
      }
    })
  }

  async ngOnInit(): Promise<void> {
    this.activeRouter.queryParamMap.subscribe((param) => {
      const courseId = param.get('courseId');
      const moduleId = param.get('moduleId');
      const lessonId = param.get('lessonId');
      if(courseId) {
        this.currentCourseId = courseId;
      } 
      if(moduleId) {
        this.currentModuleId = moduleId;
      }
      if(lessonId) {
        this.currentLessonId = +lessonId;
      }
      if(!courseId && !moduleId) {
        alert('Что то не так с ids');
      }
    });
    if(this.currentLessonId !== null) {
      this.isLessonExist = true;
      await this.getTestLessonData();
    }
  }

  onClickAddQuestion() {
    this.questions.push({
      answerOptions: [{
        isCorrectAnswer: false,
        value: ''
      }],
      question: {
        blocks: [],
        time: 0,
        version: ''
      },
      questionType: 'RadioButton'
    });
  }

  onChangeQuestionType({ questionIndex, questionType }: { questionIndex: number, questionType: QuestionType }) {
    this.questions[questionIndex].questionType = questionType;
  }

  onAddAnswerOption(questionIndex: number) {
    this.questions[questionIndex].answerOptions = [...this.questions[questionIndex].answerOptions, { ...emptyOption }];
  }

  onSelectCorrectOption({ questionIndex, optionIndex, isChecked }: { questionIndex: number, optionIndex: number, isChecked: boolean }) {
    const questionType = this.questions[questionIndex].questionType;
    if(questionType === 'RadioButton') {
      this.questions[questionIndex].answerOptions.forEach((element, index) => {
        if(index !== optionIndex) {
          element.isCorrectAnswer = false;
        } else {
          element.isCorrectAnswer = true;
        }
      });  
    } else {
      this.questions[questionIndex].answerOptions[optionIndex].isCorrectAnswer = isChecked;
    }
  }

  onChangeValueInputOption({ questionIndex, optionIndex, value }: {questionIndex: number, optionIndex: number, value: string}) {
    this.questions[questionIndex].answerOptions[optionIndex].value = value;
  }

  onChangeLessonName(name: string) {
    this.lessonName = name;
  }

  onDeleteQuest(questionIndex: number) {
    this.questions.splice(questionIndex, 1);
  }

  onDeleteAnswerOption({ questionIndex, optionIndex }: {questionIndex: number, optionIndex: number }) {
    this.questions[questionIndex].answerOptions.splice(optionIndex, 1);
  }

  async saveChanges() {
    if(this.textEditorComponent) {
      let index = 0;
      for(let e of this.textEditorComponent) {
        const data = await e.onSave();
        if(data) {
          this.questions[index].question = data;
        }
        index++;
      }
    }

    if(this.isLessonExist) {
      await this.saveChangesTestLesson()
    } else {
      await this.createTestLesson();
    }
  }

  async createTestLesson() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      method: "POST",
      body: JSON.stringify([{
        "name": this.lessonName,
        "type": "Test",
        "value": {
          questions: this.questions
        }
      }]),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    const lessonsIds = await response.json() as number[];
    if(response.ok) {
      this.isLessonExist = true;
      this.router.navigate([], {
        queryParams: {
          moduleId: this.currentModuleId,
          lessonId: lessonsIds[0],
        },
        queryParamsHandling: 'merge',
      })
      console.log('lesson test created');
    } else {
      console.log('lesson test not created');
    }
  }

  async saveChangesTestLesson() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons/${this.currentLessonId}`, {
      method: "PUT",
      body: JSON.stringify({
        "name": this.lessonName,
        "type": "Test",
        "value": {
          questions: this.questions
        }
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    if(response.ok) {
      console.log('lesson test save changes');
    } else {
      console.log('lesson test not save changes');
    }
  }

  async getTestLessonData() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      credentials: 'include',
    });
    const lessons = await response.json() as Lesson[];
    if(this.currentLessonId !== null) {
      const currLesson = lessons.filter(({ id }) => id === this.currentLessonId)[0];
      if(!currLesson) {
        return;
      }
      this.lessonName = currLesson.name;
      const testValue = currLesson.value as TestValue;
      this.questions = [...testValue.questions];
      console.log(this.questions)
    } 
  }
}
