import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-module-page',
  templateUrl: './create-module-page.component.html',
  styleUrls: ['./create-module-page.component.scss']
})
export class CreateModulePageComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onClickCreate(): void {
    this.router.navigateByUrl('/edit-course/select-lesson-type');
  }

}
