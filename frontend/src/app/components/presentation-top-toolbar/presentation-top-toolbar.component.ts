import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-presentation-top-toolbar',
  templateUrl: './presentation-top-toolbar.component.html',
  styleUrls: ['./presentation-top-toolbar.component.scss']
})
export class PresentationTopToolbarComponent implements OnInit {
  isBeforeRecord = true;
  isRecord = false;
  isDoneRecord = false;

  constructor() { }

  ngOnInit(): void {
  }

}
