import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';
import { Lesson, Slide } from 'src/typings/api/courseType';
import { PresentationLesson } from 'src/typings/presentation';

@Component({
  selector: 'app-edit-presentation-lesson-page',
  templateUrl: './edit-presentation-lesson-page.component.html',
  styleUrls: ['./edit-presentation-lesson-page.component.scss']
})
export class EditPresentationLessonPageComponent implements OnInit {
  slides: Slide[] = [];
  currentSlideIndex: number = 0;
  currentCourseId: string | null = null;
  currentModuleId: string | null = null;
  currentLessonId: number | null = null;
  lessonName: string | null = null;
  isLessonExist: boolean = false;

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
  ) {
    this.onChangeUrl();
  }

  async onChangeUrl() {
    this.router.events.pipe(filter((e) => e instanceof NavigationEnd)).subscribe(async (e) => {
      if (this.currentCourseId && this.currentModuleId) {
        await this.getLessonData();
      }
    })
  }

  async ngOnInit(): Promise<void> {
    this.activeRouter.queryParamMap.subscribe((param) => {
      const courseId = param.get('courseId');
      const moduleId = param.get('moduleId');
      const lessonId = param.get('lessonId');
      if (courseId) {
        this.currentCourseId = courseId;
      }
      if (moduleId) {
        this.currentModuleId = moduleId;
      }
      if (lessonId) {
        this.currentLessonId = +lessonId;
      }
      if (!courseId && !moduleId) {
        alert('Что то не так с ids');
      }
    });
    if (this.currentLessonId !== null) {
      this.isLessonExist = true;
      await this.getLessonData();
    }
  }

  onUploadSlide(file: File) {
    const urlSlide = URL.createObjectURL(file);
    if (this.currentSlideIndex > this.slides.length || this.slides.length === 0) {
      this.slides.push({
        description: '',
        imageSrc: urlSlide,
        voiceSrc: '',
      })
    } else {
      this.slides[this.currentSlideIndex].imageSrc = urlSlide;
    }
  }

  async onUploadPresentationFile(file: File) {
    console.log('askjfhkjsdhfkjsdhf')
    const serverImageUrls = await this.getUrlSlidesFromPresentationFile(file);
    console.log(serverImageUrls)
    await this.setSlidesFromPresentationFile(serverImageUrls);
  }

  async setSlidesFromPresentationFile(slideUrls: string[]) {
    this.slides = [];
    for (let url of slideUrls) {
      const slideUrl = await this.getFileUrlFromServer(url);
      this.slides.push({
        description: '',
        imageSrc: slideUrl,
        voiceSrc: '',
      })
    }
  }

  onChangeCurrentSlide(slideIndex: number) {
    this.currentSlideIndex = slideIndex;
  }

  onAddEmptySlide() {
    this.slides.push({
      description: '',
      imageSrc: '',
      voiceSrc: '',
    })
  }

  onDeleteSlideImage() {
    this.slides[this.currentSlideIndex].imageSrc = '';
  }

  onDeleteSlide(slideIndex: number) {
    this.slides.splice(slideIndex, 1);
  }

  onSaveVoice({ slideIndex, voiceHref }: { slideIndex: number, voiceHref: string }) {
    if (slideIndex > this.slides.length || this.slides.length === 0) {
      this.slides.push({
        description: '',
        imageSrc: '',
        voiceSrc: voiceHref,
      })
    } else {
      this.slides[this.currentSlideIndex].voiceSrc = voiceHref;
    }
  }

  onChangeLessonName(name: string) {
    this.lessonName = name;
  }

  async onSaveChanges() {
    if (this.isLessonExist) {
      await this.saveChangesLesson();
    } else {
      await this.createLesson();
    }
  }

  async createLesson() {
    const trainedSlides = await this.getTrainedSlidesForSendServer(this.slides);
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      method: "POST",
      body: JSON.stringify([{
        "name": this.lessonName,
        "type": "Presentation",
        "description": 'why?',
        "value": {
          "slides": trainedSlides,
        },
      }]),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    const lessonsIds = await response.json() as number[];
    if (response.ok) {
      this.isLessonExist = true;
      this.router.navigate([], {
        queryParams: {
          moduleId: this.currentModuleId,
          lessonId: lessonsIds[0],
        },
        queryParamsHandling: 'merge',
      })
      console.log('lesson presentation created');
    } else {
      console.log('lesson presentation not created');
    }
  }

  async getLessonData() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      credentials: 'include',
    });
    const lessons = await response.json() as Lesson[];
    if (this.currentLessonId !== null) {
      // @ts-ignore
      const currLesson = lessons.filter(({ id }) => id === this.currentLessonId)[0] as PresentationLesson;
      if (!currLesson) {
        return;
      }
      this.lessonName = currLesson.name;
      const slides = [...currLesson.value.slides];
      if (!slides) {
        return;
      }
      for (let slide of slides) {
        if (slide.imageSrc) {
          const clientUrl = await this.getFileUrlFromServer(slide.imageSrc);
          slide.imageSrc = clientUrl;
        }
        if (slide.voiceSrc) {
          const clientUrl = await this.getFileUrlFromServer(slide.voiceSrc);
          slide.voiceSrc = clientUrl;
        }
      }
      this.slides = [...slides];
    }
  }

  async saveChangesLesson() {
    const trainedSlides = await this.getTrainedSlidesForSendServer([...this.slides]);
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons/${this.currentLessonId}`, {
      method: "PUT",
      body: JSON.stringify({
        "name": this.lessonName,
        "type": "Presentation",
        "value": {
          "slides": trainedSlides
        }
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    if (response.ok) {
      console.log('lesson presentation changes save');
      const slides = [...this.slides];
      if (!slides) {
        return;
      }
      for (let slide of slides) {
        if (slide.imageSrc) {
          const clientUrl = await this.getFileUrlFromServer(slide.imageSrc);
          slide.imageSrc = clientUrl;
        }
        if (slide.voiceSrc) {
          const clientUrl = await this.getFileUrlFromServer(slide.voiceSrc);
          slide.voiceSrc = clientUrl;
        }
      }
      this.slides = [...slides];
    } else {
      console.log('lesson presentation changes not save');
    }
  }

  async getTrainedSlidesForSendServer(slides: Slide[]): Promise<Slide[]> {
    const resSlides: Slide[] = [...slides];
    for (let slide of resSlides) {
      if (slide.imageSrc) {
        const path = await this.getTrainedHref(slide.imageSrc, 'Image');
        slide.imageSrc = path.toString();
      }
      if (slide.voiceSrc) {
        const path = await this.getTrainedHref(slide.voiceSrc, 'Voice');
        slide.voiceSrc = path.toString();
      }
    }
    return resSlides;
  }

  async getTrainedHref(href: string, type: 'Image' | 'Voice') {
    const blob = await (await fetch(href)).blob();
    const file = new File([blob], 'image');
    const formData = new FormData();
    formData.append('file', file);
    const response = await fetch(`https://localhost:7144/${type}`, {
      method: "POST",
      body: formData,
      credentials: 'include',
    })
    const { path } = await response.json() as {
      "path": string;
    };
    return path;
  }

  async getFileUrlFromServer(path: string) {
    const response = await fetch(`https://localhost:7144/${path}`, {
      credentials: 'include',
    });
    const data = await response.blob();
    // const image = new File([data], 'image');
    const url = URL.createObjectURL(data);
    return url;
  }

  async getUrlSlidesFromPresentationFile(file: File) {
    const formData = new FormData();
    formData.append('file', file);
    const response = await fetch(`https://localhost:7144/presentation`, {
      method: "POST",
      body: formData,
      credentials: 'include',
    })
    const { paths } = await response.json() as {
      "paths": string[];
    };
    return paths;
  }

}
