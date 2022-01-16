import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabTechnicianComponent } from './lab-technician.component';

describe('LabTechnicianComponent', () => {
  let component: LabTechnicianComponent;
  let fixture: ComponentFixture<LabTechnicianComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabTechnicianComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabTechnicianComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
