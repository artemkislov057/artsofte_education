import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-presentation-top-toolbar',
  templateUrl: './presentation-top-toolbar.component.html',
  styleUrls: ['./presentation-top-toolbar.component.scss']
})
export class PresentationTopToolbarComponent implements OnInit {
  isBeforeRecord = true;
  isRecord = false;
  isAfterRecord = false;
  isDoneRecord = false;
  recorder: MediaRecorder | null = null;
  currentRecordTime: number = 0;
  isDeleted = false;
  voiceData: Blob[] = [];
  audioHref: SafeResourceUrl | null = null;
  @Input() audioHrefInput: string | null = null;
  @Input() currInd: number = 0;
  @Output() saveChange = new EventEmitter<string>();

  constructor(private domSanitizer: DomSanitizer) { }

  ngOnInit(): void {
    navigator.mediaDevices.getUserMedia({ audio: true })
      .then(stream => {
        this.recorder = new MediaRecorder(stream);
      });
  }

  ngOnChanges() {
    if (this.audioHrefInput) {
      this.isDoneRecord = true;
      this.isBeforeRecord = false;
      this.isAfterRecord = false;
      this.isRecord = false;
    } else {
      this.isBeforeRecord = true;
      this.isDoneRecord = false;
      this.isAfterRecord = false;
      this.isRecord = false;
    }
    this.voiceData = [];
    this._onSaveChanges();
  }

  onClickStartRecord() {
    if (this.recorder) {
      console.log('start')
      this.isRecord = true;
      this.isBeforeRecord = false;
      this.recorder.start();
      this.currentRecordTime = 0;
      const interval = setInterval(() => {
        this.currentRecordTime++;
      }, 1000)
      this.recorder.addEventListener('dataavailable', (e) => {
        clearInterval(interval)
        if (this.isDeleted) {
          this.voiceData = [];
          this.isDeleted = false;
        } else {
          this.voiceData = [e.data];
          this._onSaveChanges();
        }
      })

    }
  }

  onClickStopRecord() {
    if (this.recorder) {
      console.log('stop')
      this.recorder.stop();
      this.isRecord = false;
      this.isAfterRecord = true;
    }
  }

  onClickAccept() {
    if (this.isRecord) {
      this.onClickStopRecord();
    }
    this.isAfterRecord = false;
    this.isDoneRecord = true;

  }

  onClickDelete() {
    this.voiceData = [];
    this.isDeleted = true;
    this.isBeforeRecord = true;
    this.isAfterRecord = false;
    this.isDoneRecord = false;
    this.isRecord = false;
    this.audioHref = '';
    this.onSaveChange();
  }

  onClickCancel() {
    if (this.isRecord) {
      this.onClickStopRecord();
    }
    this.onClickDelete();
  }

  _onSaveChanges() {
    if (this.audioHrefInput) {
      this.audioHref = this.domSanitizer.bypassSecurityTrustResourceUrl(this.audioHrefInput);
    }
    if (this.voiceData.length) {
      const url = URL.createObjectURL(this.voiceData[0]);
      this.audioHref = this.domSanitizer.bypassSecurityTrustResourceUrl(url);
      this.onSaveChange();
    }
    //@ts-ignore
    this.recorder.removeAllListeners();
  }

  onSaveChange() {
    if (this.audioHref) {
      //@ts-ignore
      this.saveChange.emit(this.audioHref.changingThisBreaksApplicationSecurity);
    } else {
      this.saveChange.emit('')
    }
  }
}
