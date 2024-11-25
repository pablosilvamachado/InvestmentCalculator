import { TestBed } from '@angular/core/testing';

import { CdbService } from './api.service';

describe('ApiService', () => {
  let service: CdbService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CdbService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
