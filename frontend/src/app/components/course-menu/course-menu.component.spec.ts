import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseMenuComponent } from './course-menu.component';

describe('CourseMenuComponent', () => {
  let component: CourseMenuComponent;
  let fixture: ComponentFixture<CourseMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseMenuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
