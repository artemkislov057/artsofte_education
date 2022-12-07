import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoursePreviewContainerComponent } from './course-preview-container.component';

describe('CoursePreviewContainerComponent', () => {
  let component: CoursePreviewContainerComponent;
  let fixture: ComponentFixture<CoursePreviewContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CoursePreviewContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CoursePreviewContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
