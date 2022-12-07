import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateModulePageComponent } from './create-module-page.component';

describe('CreateModulePageComponent', () => {
  let component: CreateModulePageComponent;
  let fixture: ComponentFixture<CreateModulePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateModulePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateModulePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
