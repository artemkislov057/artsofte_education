import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopToolarContainerComponent } from './top-toolar-container.component';

describe('TopToolarContainerComponent', () => {
  let component: TopToolarContainerComponent;
  let fixture: ComponentFixture<TopToolarContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopToolarContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopToolarContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
