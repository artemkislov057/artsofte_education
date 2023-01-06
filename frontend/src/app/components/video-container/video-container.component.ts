import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-video-container',
  templateUrl: './video-container.component.html',
  styleUrls: ['./video-container.component.scss']
})
export class VideoContainerComponent implements OnInit {
  @Input() youtubeHref: SafeUrl | string | null = null;
  @Input() videoHref: SafeUrl | string | null = null;
  @Output() onChangeYoutubeHref = new EventEmitter<string | null>();
  @Output() onChangeVideoFile = new EventEmitter<File | null>();


  constructor(private domSanitizer: DomSanitizer) {

  }

  ngOnChanges() {
    if(this.youtubeHref) {
      this.youtubeHref = this.domSanitizer.bypassSecurityTrustResourceUrl(this.youtubeHref as string);
    }
    if(this.videoHref) {
      this.videoHref = this.domSanitizer.bypassSecurityTrustUrl(this.videoHref as string);
    }
  }

  ngOnInit(): void {
    if(this.youtubeHref) {
      this.youtubeHref = this.domSanitizer.bypassSecurityTrustResourceUrl(this.youtubeHref as string);
    }
    if(this.videoHref) {
      this.videoHref = this.domSanitizer.bypassSecurityTrustUrl(this.videoHref as string);
    }
  }

  onUploadVideo(fileList: FileList | null) {
    if(!fileList) {
      return;
    }
    const file = fileList[0];
    this.setVideoFile(file);

    const blobUrl = URL.createObjectURL(file);
    this.videoHref = this.domSanitizer.bypassSecurityTrustUrl(blobUrl);
  }

  setVideoFile(file: File) {
    this.onChangeVideoFile.emit(file);
  }

  changeYoutubeHref(href: string) {
    //при условии что ссылка с ютуба, иначе гг
    const corrctedHref = href.replace('watch?v=', 'embed/');
    this.youtubeHref = this.domSanitizer.bypassSecurityTrustResourceUrl(corrctedHref);
    this.onChangeYoutubeHref.emit(corrctedHref);
  }

  onClickDelete() {
    this.onChangeYoutubeHref.emit(null);
    this.onChangeVideoFile.emit(null);
    this.youtubeHref = null;
    this.videoHref = null;
  }
}
