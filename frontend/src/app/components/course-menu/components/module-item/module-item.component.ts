import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-module-item',
  templateUrl: './module-item.component.html',
  styleUrls: ['./module-item.component.scss']
})
export class ModuleItemComponent implements OnInit {
  @Input() title: string = '';
  @Input() isActive: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
