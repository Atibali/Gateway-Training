import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Subject } from 'rxjs';

import { ProductList } from './product-list';
import { Product } from '../product.model';
import { ProductService } from '../product';

describe('ProductList', () => {
  let component: ProductList;
  let fixture: ComponentFixture<ProductList>;
  let products: Subject<Product[]>;

  beforeEach(async () => {
    products = new Subject<Product[]>();
    await TestBed.configureTestingModule({
      imports: [ProductList],
      providers: [
        {
          provide: ProductService,
          useValue: { getProducts: () => products.asObservable() },
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

  it('renders products when the request completes asynchronously', async () => {
    products.next([{ id: 1, name: 'Laptop', price: 55000, stock: 10 }]);
    await fixture.whenStable();

    expect(fixture.nativeElement.textContent).toContain('Laptop');
    expect(fixture.nativeElement.textContent).not.toContain('Loading products...');
  });
});
