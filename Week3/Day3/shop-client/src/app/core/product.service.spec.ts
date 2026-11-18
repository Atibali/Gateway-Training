import { TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { ProductService } from './product.service';

describe('ProductService', () => {
  let service: ProductService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideHttpClient(), provideHttpClientTesting()],
    });
    service = TestBed.inject(ProductService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => httpMock.verify());

  it('uses the API plain-text delete response', () => {
    let response = '';
    service.deleteProduct(42).subscribe((message) => (response = message));

    const request = httpMock.expectOne('http://localhost:5024/api/products/42');
    expect(request.request.method).toBe('DELETE');
    expect(request.request.responseType).toBe('text');
    request.flush('Product Deleted Successfully');

    expect(response).toBe('Product Deleted Successfully');
  });
});
