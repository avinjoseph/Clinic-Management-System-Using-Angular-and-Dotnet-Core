import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctornotesComponent } from './doctornotes.component';

describe('DoctornotesComponent', () => {
  let component: DoctornotesComponent;
  let fixture: ComponentFixture<DoctornotesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DoctornotesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctornotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
