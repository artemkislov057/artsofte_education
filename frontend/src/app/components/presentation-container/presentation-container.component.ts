import { Component, ElementRef, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Slide } from 'src/typings/api/courseType';


@Component({
  selector: 'app-presentation-container',
  templateUrl: './presentation-container.component.html',
  styleUrls: ['./presentation-container.component.scss']
})
export class PresentationContainerComponent implements OnInit {
  @Input() currentSlideIndex: number = 0;
  @Input() slides: Slide[] = [];
  @Output() uploadSlide = new EventEmitter<File>();
  @Output() changeCurrentSlide = new EventEmitter<number>();
  @Output() addSlide = new EventEmitter();
  @Output() deleteSlideImage = new EventEmitter();
  @Output() deleteSlide = new EventEmitter<number>();
  @Output() saveVoiceChanges = new EventEmitter<{ slideIndex: number; voiceHref: string }>();

  constructor(private domSanitizer: DomSanitizer,
    private elem: ElementRef) { }

  ngOnInit(): void {
  }

  async uploadPresentation(fileList: FileList | null) {
    if (fileList === null) {
      return;
    }

    const file = fileList[0];
    const url = URL.createObjectURL(file);
  }

  onUploadSlide(fileList: FileList | null) {
    if (fileList) {
      this.uploadSlide.emit(fileList[0]);
    }
  }

  onChangeCurrent(index: number) {
    this.changeCurrentSlide.emit(index);
  }

  onAddSlide() {
    this.addSlide.emit();
  }

  onDeleteSlideImage() {
    this.deleteSlideImage.emit();
  }

  onDeleteSlide(slideIndex: number) {
    this.deleteSlide.emit(slideIndex);
  }

  onClickScrollButton(scrollTo: 'right' | 'left') {
    const el = this.elem.nativeElement.querySelector('.wrapper') as HTMLElement;
    const delta = scrollTo === 'right' ? 140 : -140;
    el.scrollBy({ left: delta, behavior: 'smooth' })
  }

  onSaveVoiceChange(href: string, currentSlideIndex: number) {
    this.saveVoiceChanges.emit({
      slideIndex: currentSlideIndex,
      voiceHref: href,
    });
  }

  getSafeUrl(unsafeUrl: string) {
    return this.domSanitizer.bypassSecurityTrustUrl(unsafeUrl);
  }
}
