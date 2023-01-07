import { Component, OnInit, ViewChildren } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { OutputData } from '@editorjs/editorjs';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import { TextEditorComponent } from 'src/app/components/text-editor/text-editor.component';
import { AppState } from 'src/app/store/states/app.state';
import { Lesson, VideoValue } from 'src/typings/api/courseType';

@Component({
  selector: 'app-edit-video-lesson-page',
  templateUrl: './edit-video-lesson-page.component.html',
  styleUrls: ['./edit-video-lesson-page.component.scss']
})
export class EditVideoLessonPageComponent implements OnInit {
  currentCourseId: string | null = null;
  currentModuleId: string | null = null;
  currentLessonId: number | null = null;
  lessonName: string | null = null;
  existsTextData: OutputData | null = null;
  isLessonExist: boolean = false;
  hrefYoutubeVideo: string | null = null;
  hrefVideo: string | null = null;
  videoFile: File | null = null;
  
  @ViewChildren(TextEditorComponent) textEditorComponent: TextEditorComponent | null = null;

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
        await this.getAndSetExistsData();
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
      await this.getAndSetExistsData();
    }
  }

  onChangeLessonName(name: string) {
    this.lessonName = name;
  }

  onChangeYoutubeHref(href: string | null) {
    this.hrefYoutubeVideo = href;
  }

  onChangeVideoFile(file: File | null) {
    this.videoFile = file;
  }

  async getAndSetExistsData(): Promise<void> {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      credentials: 'include',
    });
    const lessons = await response.json() as Lesson[];
    if(this.currentLessonId !== null) {
      const currLesson = lessons.filter(({ id }) => id === this.currentLessonId)[0];
      if(!currLesson) {
        return;
      }
      const result = currLesson.additionalText as OutputData;
      this.existsTextData = result;
      console.log(this.existsTextData)
      this.lessonName = currLesson.name;
      const videoValue = currLesson.value as VideoValue;
      if(!videoValue) {
        return;
      }
      if(videoValue.videoType === "YouTube") {
        this.hrefYoutubeVideo = videoValue.src;
        this.hrefVideo = '';
        this.videoFile = null;
      } else {
        this.hrefYoutubeVideo = '';
        const { videoUrl, videoFile } = await this.getVideoFileFromServer(videoValue.src);
        this.hrefVideo = videoUrl;
        this.videoFile = videoFile;
      }
    } 
  }

  async saveChanges() {
    let textData: OutputData | null = null;
    if(this.textEditorComponent) {
        //@ts-ignore
        const data = await this.textEditorComponent.first.onSave();
        console.log(data)
        if(data) {
          textData = data;
        }
    }
    // обработать момент, когда видео может отсылаться в виде ссылки или в виде файла
    if(this.isLessonExist) {
      if(this.hrefYoutubeVideo) {
        this.saveVideoLessonChanges(textData, this.hrefYoutubeVideo, 'YouTube');
      } else if(this.videoFile) {
        const href = await this.sendVideoFileOnServer(this.videoFile);
        this.saveVideoLessonChanges(textData, href, 'Internal');
      }
    } else {
      if(this.hrefYoutubeVideo) {
        this.createVideoLesson(textData, this.hrefYoutubeVideo, 'YouTube');
      } else if(this.videoFile) {
        const href = await this.sendVideoFileOnServer(this.videoFile);
        this.createVideoLesson(textData, href, 'Internal');
      }
    }
  }

  async saveVideoLessonChanges(textData: OutputData | null, href: string, type: 'YouTube' | 'Internal') {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons/${this.currentLessonId}`, {
      method: "PUT",
      body: JSON.stringify({
        "name": this.lessonName,
        "type": "Video",
        "value": {
          "videoType": type,
          "src": href,
        },
        "additionalText": textData,
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    if(response.ok) {
      console.log('lesson with video href changes save');
    } else {
      console.log('lesson with video href changes not save');
    }
  }

  async createVideoLesson(textData: OutputData | null, href: string, type: 'YouTube' | 'Internal') {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      method: "POST",
      body: JSON.stringify([{
        "name": this.lessonName,
        "type": "Video",
        "description": 'why?',
        "value": {
          "videoType": type,
          "src": href,
        },
        "additionalText": textData,
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
      console.log('lesson with video href created');
    } else {
      console.log('lesson with video href not created');
    }
  }

  async sendVideoFileOnServer(file: File): Promise<string> {
    const formData = new FormData();
    formData.append('file', file);

    const response = await fetch(`https://localhost:7144/Video`, {
      method: "POST",
      body: formData,
      credentials: 'include',
    })
    const { path } = await response.json() as {
      "path": string;
    };
    return path;
  }

  async getVideoFileFromServer(path: string) {
    const response = await fetch(`https://localhost:7144/${path}`, {
      credentials: 'include',
    });
    const data = await response.blob();
    const video = new File([data], 'video', { type: 'video/mp4' });
    const videoUrl = URL.createObjectURL(video)
    return {
      videoUrl,
      videoFile: video,
    };
  }
}
