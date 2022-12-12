import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-type-buttons',
  templateUrl: './test-type-buttons.component.html',
  styleUrls: ['./test-type-buttons.component.scss']
})
export class TestTypeButtonsComponent implements OnInit {
  @Input() isActiveRadio: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

}
