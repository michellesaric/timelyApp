import { TestBed } from '@angular/core/testing';

import { APIcallsService } from './apicalls.service';

describe('APIcallsService', () => {
  let service: APIcallsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(APIcallsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
