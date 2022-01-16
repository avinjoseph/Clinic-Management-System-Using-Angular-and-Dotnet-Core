import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionHistoryComponent } from './prescription-history.component';

describe('PrescriptionHistoryComponent', () => {
  let component: PrescriptionHistoryComponent;
  let fixture: ComponentFixture<PrescriptionHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrescriptionHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrescriptionHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
