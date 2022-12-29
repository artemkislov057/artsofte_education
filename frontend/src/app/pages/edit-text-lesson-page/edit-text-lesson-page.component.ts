import { Component, OnInit, SimpleChanges, ViewChild, ViewChildren } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { OutputData } from '@editorjs/editorjs';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import { TextEditorComponent } from 'src/app/components/text-editor/text-editor.component';
import { AppState } from 'src/app/store/states/app.state';
import { Lesson } from 'src/typings/api/courseType';

@Component({
  selector: 'app-edit-text-lesson-page',
  templateUrl: './edit-text-lesson-page.component.html',
  styleUrls: ['./edit-text-lesson-page.component.scss']
})
export class EditTextLessonPageComponent implements OnInit {
  currentCourseId: string | null = null;
  currentModuleId: string | null = null;
  currentLessonId: number | null = null;
  lessonName: string | null = null;
  existsTextData: OutputData[] = [];

  @ViewChildren(TextEditorComponent) textEditorComponent: TextEditorComponent[] | null = null;

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) { 
    this.onChangeUrl();
    // console.log('constructor')
  }

  async onChangeUrl() {
    this.router.events.pipe(filter((e) => e instanceof NavigationEnd)).subscribe(async (e) => {
      if(this.currentCourseId && this.currentModuleId) {
        await this.getExistsTextData();

      }
    })
  }

  ngOnDestroy() {

  }

  ngOnChanges(changes: SimpleChanges) {
    // console.log('aaas')
  }

  async ngOnInit() {
    console.log('onInit')
    console.log(this.existsTextData);
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
      await this.getExistsTextData();
      console.log(this.existsTextData);
    }
  }

  ngAfterViewInit(): void {
    // console.log('onViewInit', this.textEditorComponent)
    // this.setExistsTextData();
  }

  async setExistsTextData() {
    if(this.currentLessonId !== null) {
      const textData = await this.getExistsTextData();
      if(textData) {
        this.existsTextData = textData;
        // this.textEditorComponent?.map((component, i) => {
        //   // component.setExistsData(textData[i])
        // })
      }
    }
  }

  onChangeLessonName(name: string) {
    this.lessonName = name;
  }

  async testSave() {
    const textData: OutputData[] = [];
    if(this.textEditorComponent) {
      for(let e of this.textEditorComponent) {
        const data = await e.onSave();
        if(data) {
          textData.push(data);
        }
      }
    }
    this.createLesson(textData)
  }

  async createLesson(textData: OutputData[]) {
    console.log(textData)
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      method: "POST",
      body: JSON.stringify([{
        "name": this.lessonName,
        "type": "Text",
        "description": 'why?',
        "value": {
          time: textData[0].time,
          version: textData[0].version,
          blocks: textData[0].blocks,
        },
        "additionalText": {
          time: textData[1].time,
          version: textData[1].version,
          blocks: textData[1].blocks,
        }
        }
      ]),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    if(response.ok) {
      console.log('lesson created');
    } else {
      console.log('lesson not created');
    }
  }

  async getExistsTextData() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      credentials: 'include',
    });
    const lessons = await response.json() as Lesson[];
    if(this.currentLessonId !== null) {
      const currLesson = lessons.filter(({ id }) => id === this.currentLessonId)[0];
      if(!currLesson) {
        return null;
      }
      const result = [currLesson?.value, currLesson.additionalText as OutputData];
      this.existsTextData = [...result] as OutputData[];
      this.lessonName = currLesson.name;
      return result;
    } 
    return null;
  }
}
