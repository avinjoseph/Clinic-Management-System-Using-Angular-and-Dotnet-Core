import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabresultsComponent } from './labresults.component';

describe('LabresultsComponent', () => {
  let component: LabresultsComponent;
  let fixture: ComponentFixture<LabresultsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabresultsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabresultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
