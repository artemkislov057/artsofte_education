import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { OutputData } from '@editorjs/editorjs';
import { filter } from 'rxjs';
import { Lesson } from 'src/typings/api/courseType';
import { BookItem, LiteratureLesson } from 'src/typings/literature';

@Component({
  selector: 'app-edit-additional-material-page',
  templateUrl: './edit-additional-material-page.component.html',
  styleUrls: ['./edit-additional-material-page.component.scss']
})
export class EditAdditionalMaterialPageComponent implements OnInit {
  books: BookItem[] = [];
  curentBookIndex: number = 0;
  currentCourseId: string | null = null;
  currentModuleId: string | null = null;
  currentLessonId: number | null = null;
  lessonName: string | null = 'Дополнительная литература';
  isLessonExist: boolean = false;

  constructor(
    private router: Router,
    private activeRouter: ActivatedRoute,
  ) {
    this.onChangeUrl();
  }

  async onChangeUrl() {
    this.router.events.pipe(filter((e) => e instanceof NavigationEnd)).subscribe(async (e) => {
      if(this.currentCourseId && this.currentModuleId) {
        await this.getLessonData();
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
      await this.getLessonData();
    }
  }

  onUploadCover(file: File) {
    const urlCover = URL.createObjectURL(file);
    if(this.curentBookIndex > this.books.length || this.books.length === 0) {
      this.books.push({
        coverSrc: urlCover,
        description: '',
        name: '',
        purchaseLinks: [],
      })
    } else {
      this.books[this.curentBookIndex].coverSrc = urlCover;
    }
  }

  onChangeCurrentBook(bookIndex: number) {
    this.curentBookIndex = bookIndex;
  }

  onAddEmptyBook() {
    this.books.push({
      coverSrc: '',
      description: '',
      name: '',
      purchaseLinks: [],
    })
  }

  onChangeHref(href: string) {
    if(this.curentBookIndex > this.books.length || this.books.length === 0) {
      this.books.push({
        coverSrc: '',
        description: '',
        name: '',
        purchaseLinks: [href],
      })
    } else {
      this.books[this.curentBookIndex].purchaseLinks = [href];
    }
  }

  onDeleteCover() {
    this.books[this.curentBookIndex].coverSrc = '';
  }

  onChangeLessonName(name: string) {
    this.lessonName = name;
  }

  async onSaveChanges() {
    if(this.isLessonExist) {
      await this.saveChangesLesson();
    } else {
      await this.createLesson();
    }
  }

  async createLesson() {
    const trainedBooks = await this.getTrainedBooksForSendServer(this.books);
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      method: "POST",
      body: JSON.stringify([{
        "name": this.lessonName,
        "type": "Literature",
        "description": 'why?',
        "value": {
          "elements": trainedBooks,
        },
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
      console.log('lesson literature created');
    } else {
      console.log('lesson literature not created');
    }
  }

  async getLessonData() {
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons`, {
      credentials: 'include',
    });
    const lessons = await response.json() as Lesson[];
    if(this.currentLessonId !== null) {
      //@ts-ignore
      const currLesson = lessons.filter(({ id }) => id === this.currentLessonId)[0] as LiteratureLesson;
      if(!currLesson) {
        return;
      }
      this.lessonName = currLesson.name;
      const books = [...currLesson.value.elements];
      if(!books) {
        return;
      }
      for(let book of books) {
        if(book.coverSrc) {
          const clientUrl = await this.getImageUrlFromServer(book.coverSrc);
          book.coverSrc = clientUrl;
        }
      }
      this.books = [...books];
    } 
  }

  async saveChangesLesson() {
    const trainedBooks = await this.getTrainedBooksForSendServer([...this.books]);
    const response = await fetch(`https://localhost:5001/api/courses/${this.currentCourseId}/modules/${this.currentModuleId}/lessons/${this.currentLessonId}`, {
      method: "PUT",
      body: JSON.stringify({
        "name": this.lessonName,
        "type": "Literature",
        "value": {
          "elements": trainedBooks
        }
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    if(response.ok) {
      console.log('lesson literature changes save');
      const books = [...this.books];
      if(!books) {
        return;
      }
      for(let book of books) {
        if(book.coverSrc) {
          const clientUrl = await this.getImageUrlFromServer(book.coverSrc);
          book.coverSrc = clientUrl;
        }
      }
      this.books = [...books];
    } else {
      console.log('lesson literature changes not save');
    }
  }

  async getTrainedBooksForSendServer(books: BookItem[]): Promise<BookItem[]> {
    const resBooks: BookItem[] = [...books];
    for(let book of resBooks) {
      if(book.coverSrc) {
        const path = await this.getTrainedHref(book.coverSrc);
        book.coverSrc = path.toString();
      }
    }
    return resBooks;
  }

  async getTrainedHref(href: string) {
    const blob = await (await fetch(href)).blob();
    const file = new File([blob], 'image');
    const formData = new FormData();
    formData.append('file', file);
    const response = await fetch(`https://localhost:7144/Image`, {
      method: "POST",
      body: formData,
      credentials: 'include',
    })
    const { path } = await response.json() as {
      "path": string;
    };
    return path;
  }

  async getImageUrlFromServer(path: string) {
    const response = await fetch(`https://localhost:7144/${path}`, {
      credentials: 'include',
    });
    const data = await response.blob();
    // const image = new File([data], 'image');
    const imageUrl = URL.createObjectURL(data);
    return imageUrl;
  }
}
