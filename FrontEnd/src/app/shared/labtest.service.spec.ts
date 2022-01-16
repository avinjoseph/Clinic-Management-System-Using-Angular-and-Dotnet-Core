import { TestBed } from '@angular/core/testing';

import { LabtestService } from './labtest.service';

describe('LabtestService', () => {
  let service: LabtestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabtestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
