import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabTypeComponent } from './cab-type.component';

describe('CabTypeComponent', () => {
  let component: CabTypeComponent;
  let fixture: ComponentFixture<CabTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
