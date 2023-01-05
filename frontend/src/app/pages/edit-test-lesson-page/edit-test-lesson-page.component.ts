import { Component, OnInit, ViewChildren } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { OutputData } from '@editorjs/editorjs';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import { TextEditorComponent } from 'src/app/components/text-editor/text-editor.component';
import { AppState } from 'src/app/store/states/app.state';
import { AnswerOption, QuestionType, TestQuestion } from 'src/typings/test';

const emptyOption: AnswerOption = {
  isCorrect: false,
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
        // await this.getAndSetExistsData();
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
      // await this.getExistsTextData();
    }
  }

  onClickAddQuestion() {
    this.questions.push({
      answerOptions: [{
        isCorrect: false,
        value: ''
      }],
      question: {
        blocks: [],
        time: 0,
        version: ''
      },
      questionType: 'radio'
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
    if(questionType === 'radio') {
      this.questions[questionIndex].answerOptions.forEach((element, index) => {
        if(index !== optionIndex) {
          element.isCorrect = false;
        } else {
          element.isCorrect = true;
        }
      });  
    } else {
      this.questions[questionIndex].answerOptions[optionIndex].isCorrect = isChecked;
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
    console.log(this.questions)
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
    //
  }

  async createTestLesson() {

  }

  async saveChangesTestLesson() {

  }

  async getTestLessonData() {

  }

  async setTestLessonData() {

  }
}
