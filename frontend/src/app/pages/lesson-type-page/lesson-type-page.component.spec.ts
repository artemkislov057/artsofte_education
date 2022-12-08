import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonTypePageComponent } from './lesson-type-page.component';

describe('LessonTypePageComponent', () => {
  let component: LessonTypePageComponent;
  let fixture: ComponentFixture<LessonTypePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonTypePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LessonTypePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
