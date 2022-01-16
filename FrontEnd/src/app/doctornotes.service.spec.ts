import { TestBed } from '@angular/core/testing';

import { DoctornotesService } from './doctornotes.service';

describe('DoctornotesService', () => {
  let service: DoctornotesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctornotesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
