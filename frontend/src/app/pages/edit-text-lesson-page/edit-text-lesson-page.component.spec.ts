import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTextLessonPageComponent } from './edit-text-lesson-page.component';

describe('EditTextLessonPageComponent', () => {
  let component: EditTextLessonPageComponent;
  let fixture: ComponentFixture<EditTextLessonPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTextLessonPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditTextLessonPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
