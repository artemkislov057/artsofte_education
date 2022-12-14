import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PresentationTopToolbarComponent } from './presentation-top-toolbar.component';

describe('PresentationTopToolbarComponent', () => {
  let component: PresentationTopToolbarComponent;
  let fixture: ComponentFixture<PresentationTopToolbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PresentationTopToolbarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PresentationTopToolbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
