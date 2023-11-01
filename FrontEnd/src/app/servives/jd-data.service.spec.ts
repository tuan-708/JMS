import { TestBed } from '@angular/core/testing';

import { JdDataService } from './jd-data.service';

describe('JdDataService', () => {
  let service: JdDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JdDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
