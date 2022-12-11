import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditVideoLessonPageComponent } from './edit-video-lesson-page.component';

describe('EditVideoLessonPageComponent', () => {
  let component: EditVideoLessonPageComponent;
  let fixture: ComponentFixture<EditVideoLessonPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditVideoLessonPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditVideoLessonPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
