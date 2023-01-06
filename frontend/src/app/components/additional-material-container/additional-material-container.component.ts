import { Component, ElementRef, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { BookItem } from 'src/typings/literature';

@Component({
  selector: 'app-additional-material-container',
  templateUrl: './additional-material-container.component.html',
  styleUrls: ['./additional-material-container.component.scss']
})
export class AdditionalMaterialContainerComponent implements OnInit {
  @Input() currentBookIndex: number = 0;
  @Input() books: BookItem[] = [];
  @Output() uploadCover = new EventEmitter<File>();
  @Output() changeCurrentBook = new EventEmitter<number>();
  @Output() addBook = new EventEmitter();
  @Output() changeHref = new EventEmitter<string>();
  @Output() deleteCover = new EventEmitter();
  currentHref: string = '';

  constructor(private domSanitizer: DomSanitizer,
    private elem: ElementRef
    ) { }

  ngOnChanges() {
    this.currentHref = this.books[this.currentBookIndex]?.purchaseLinks[0] || '';
  }

  ngOnInit(): void {
  }

  onUploadCover(files: FileList  | null) {
    if(files) {
      this.uploadCover.emit(files[0]);
    }
  }

  onChangeCurrent(index: number) {
    this.changeCurrentBook.emit(index);
  }

  onAddBook() {
    this.addBook.emit();
  }

  getSafeUrl(unsafeUrl: string) {
    return this.domSanitizer.bypassSecurityTrustUrl(unsafeUrl);
  }

  onChangeHref(href: string) {
    this.changeHref.emit(this.currentHref);
  }

  onDeleteCover() {
    this.deleteCover.emit();
  }

  onClickScrollButton(scrollTo: 'right' | 'left') {
    const el = this.elem.nativeElement.querySelector('.wrapper') as HTMLElement;
    const delta = scrollTo === 'right' ? 140 : -140;
    el.scrollBy({left: delta, behavior: 'smooth'})
  }
}
