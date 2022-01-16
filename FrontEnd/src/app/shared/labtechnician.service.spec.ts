import { TestBed } from '@angular/core/testing';

import { LabtechnicianService } from './labtechnician.service';

describe('LabtechnicianService', () => {
  let service: LabtechnicianService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabtechnicianService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
