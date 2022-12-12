import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAdditionalMaterialPageComponent } from './edit-additional-material-page.component';

describe('EditAdditionalMaterialPageComponent', () => {
  let component: EditAdditionalMaterialPageComponent;
  let fixture: ComponentFixture<EditAdditionalMaterialPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAdditionalMaterialPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditAdditionalMaterialPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
