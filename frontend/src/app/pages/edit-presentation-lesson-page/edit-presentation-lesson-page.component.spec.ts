import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPresentationLessonPageComponent } from './edit-presentation-lesson-page.component';

describe('EditPresentationLessonPageComponent', () => {
  let component: EditPresentationLessonPageComponent;
  let fixture: ComponentFixture<EditPresentationLessonPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPresentationLessonPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditPresentationLessonPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
