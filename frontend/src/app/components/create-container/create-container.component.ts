import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-create-container',
  templateUrl: './create-container.component.html',
  styleUrls: ['./create-container.component.scss']
})
export class CreateContainerComponent implements OnInit {
  @Input() typeContainerName: 'курса' | 'модуля' = 'курса';
  @Output() onClickCreate = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  create(): void {
    this.onClickCreate.emit();
  }

}
