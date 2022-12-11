import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditionalMaterialContainerComponent } from './additional-material-container.component';

describe('AdditionalMaterialContainerComponent', () => {
  let component: AdditionalMaterialContainerComponent;
  let fixture: ComponentFixture<AdditionalMaterialContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditionalMaterialContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdditionalMaterialContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
