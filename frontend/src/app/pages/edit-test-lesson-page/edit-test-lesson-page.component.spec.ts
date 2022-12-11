import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTestLessonPageComponent } from './edit-test-lesson-page.component';

describe('EditTestLessonPageComponent', () => {
  let component: EditTestLessonPageComponent;
  let fixture: ComponentFixture<EditTestLessonPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTestLessonPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditTestLessonPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
