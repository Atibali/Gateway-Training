import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { Subject } from 'rxjs';
import { Product } from '../core/product';
import { ProductService } from '../core/product.service';

import { ProductList } from './product-list';

describe('ProductList', () => {
  let component: ProductList;
  let fixture: ComponentFixture<ProductList>;
  let productsResponse: Subject<Product[]>;

  beforeEach(async () => {
    productsResponse = new Subject<Product[]>();
    await TestBed.configureTestingModule({
      imports: [ProductList],
      providers: [
        provideRouter([]),
        {
          provide: ProductService,
          useValue: { getProducts: () => productsResponse.asObservable() },
        },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(ProductList);
    component = fixture.componentInstance;
    fixture.detectChanges();
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should show an empty state when the API returns no products', async () => {
    productsResponse.next([]);
    await fixture.whenStable();
    expect(fixture.nativeElement.textContent).toContain('No products yet');
  });

  it('should render products when the API responds asynchronously', async () => {
    productsResponse.next([
      { id: 1, name: 'Training book', description: 'Angular notes', price: 12, quantity: 3 },
    ]);
    await fixture.whenStable();

    expect(fixture.nativeElement.textContent).toContain('Training book');
    expect(fixture.nativeElement.textContent).not.toContain('Loading products');
  });
});
