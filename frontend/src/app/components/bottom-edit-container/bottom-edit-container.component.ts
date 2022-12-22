import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-bottom-edit-container',
  templateUrl: './bottom-edit-container.component.html',
  styleUrls: ['./bottom-edit-container.component.scss']
})
export class BottomEditContainerComponent implements OnInit {
  @Output() saveLesson = new EventEmitter();
  @Output() cancel = new EventEmitter();


  constructor() { }

  ngOnInit(): void {
  }

  onClickSave() {
    this.saveLesson.emit();
  }

  onClickCancel() {
    this.cancel.emit();
  }

}
