import { TestBed } from '@angular/core/testing';

import { TestReportService } from './test-report.service';

describe('TestReportService', () => {
  let service: TestReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
