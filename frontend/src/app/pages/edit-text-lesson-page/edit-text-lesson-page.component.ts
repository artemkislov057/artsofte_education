import { Component, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OutputData } from '@editorjs/editorjs';
import { Store } from '@ngrx/store';
import { TextEditorComponent } from 'src/app/components/text-editor/text-editor.component';
import { AppState } from 'src/app/store/states/app.state';

@Component({
  selector: 'app-edit-text-lesson-page',
  templateUrl: './edit-text-lesson-page.component.html',
  styleUrls: ['./edit-text-lesson-page.component.scss']
})
export class EditTextLessonPageComponent implements OnInit {
  currentCourseId: string | null = null;
  currentModuleId: string | null = null;
  lessonName: string | null = null;

  @ViewChildren(TextEditorComponent) textEditorComponent: TextEditorComponent[] | null = null;

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
    private _store: Store<AppState>,
  ) { }

  ngOnInit(): void {
    this.activeRouter.queryParamMap.subscribe((param) => {
      const courseId = param.get('courseId');
      const moduleId = param.get('moduleId');
      if(courseId) {
        this.currentCourseId = courseId;
      } 
      if(moduleId) {
        this.currentModuleId = moduleId;
      }
      if(!courseId && !moduleId) {
        alert('Что то не так с ids');
      }
    })
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
}
