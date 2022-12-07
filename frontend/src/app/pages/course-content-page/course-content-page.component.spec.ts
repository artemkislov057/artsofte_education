import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseContentPageComponent } from './course-content-page.component';

describe('CourseContentPageComponent', () => {
  let component: CourseContentPageComponent;
  let fixture: ComponentFixture<CourseContentPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseContentPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseContentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
