import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestreportComponent } from './testreport.component';

describe('TestreportComponent', () => {
  let component: TestreportComponent;
  let fixture: ComponentFixture<TestreportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestreportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestreportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
