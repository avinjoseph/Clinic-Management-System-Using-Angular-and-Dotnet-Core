import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientappointmentsComponent } from './patientappointments.component';

describe('PatientappointmentsComponent', () => {
  let component: PatientappointmentsComponent;
  let fixture: ComponentFixture<PatientappointmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientappointmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientappointmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
