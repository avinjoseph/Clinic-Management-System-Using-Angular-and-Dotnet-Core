import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabtestComponent } from './labtest.component';

describe('LabtestComponent', () => {
  let component: LabtestComponent;
  let fixture: ComponentFixture<LabtestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabtestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabtestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
