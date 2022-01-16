import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestreportsListComponent } from './testreports-list.component';

describe('TestreportsListComponent', () => {
  let component: TestreportsListComponent;
  let fixture: ComponentFixture<TestreportsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestreportsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestreportsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
