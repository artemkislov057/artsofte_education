import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestTypeButtonsComponent } from './test-type-buttons.component';

describe('TestTypeButtonsComponent', () => {
  let component: TestTypeButtonsComponent;
  let fixture: ComponentFixture<TestTypeButtonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestTypeButtonsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TestTypeButtonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
