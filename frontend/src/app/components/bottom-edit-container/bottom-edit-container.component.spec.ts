import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottomEditContainerComponent } from './bottom-edit-container.component';

describe('BottomEditContainerComponent', () => {
  let component: BottomEditContainerComponent;
  let fixture: ComponentFixture<BottomEditContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottomEditContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BottomEditContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
