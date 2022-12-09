import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonNameContainerComponent } from './lesson-name-container.component';

describe('LessonNameContainerComponent', () => {
  let component: LessonNameContainerComponent;
  let fixture: ComponentFixture<LessonNameContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonNameContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LessonNameContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
