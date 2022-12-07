import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-container',
  templateUrl: './create-container.component.html',
  styleUrls: ['./create-container.component.scss']
})
export class CreateContainerComponent implements OnInit {
  @Input() typeContainerName: 'курса' | 'модуля' = 'курса'
  constructor() { }

  ngOnInit(): void {
  }

}
