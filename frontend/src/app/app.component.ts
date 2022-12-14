import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from './store/states/app.state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private route: Router, private _store: Store<AppState>) {
    this.login();
  }

  async login() {
    const response = await fetch('https://localhost:5001/api/users/login', {
      method: "POST",
      body: JSON.stringify({
        "name": "user1",
        "password": "string",
        "isPersistent": true,
      }),
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    if(response.ok) {
      console.log('isLoginned');
    } else {
      alert('Проблема с логином')
    }
  }

  onClickCreateCourse(): void {
    this.route.navigateByUrl('/create-course');
  }

  onClickHomeButton(): void {
    this.route.navigateByUrl('/');
  }

 }
