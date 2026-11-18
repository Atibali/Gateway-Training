import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, provideRouter } from '@angular/router';
import { of } from 'rxjs';
import { ProductService } from '../core/product.service';
import { ProductForm } from './product-form';

describe('ProductForm', () => {
  let component: ProductForm;
  let fixture: ComponentFixture<ProductForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductForm],
      providers: [
        provideRouter([]),
        {
          provide: ActivatedRoute,
          useValue: { snapshot: { paramMap: { get: () => null } } },
        },
        {
          provide: ProductService,
          useValue: {
            createProduct: () => of({}),
            updateProduct: () => of({}),
            getProduct: () => of({}),
          },
        },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(ProductForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('rejects fractional quantities before sending them to the integer API field', () => {
    component.form.controls.quantity.setValue(1.5);

    expect(component.form.controls.quantity.hasError('pattern')).toBe(true);
    expect(component.form.invalid).toBe(true);
  });

  it('disables save only while saving or after a product-load failure', () => {
    const button = fixture.nativeElement.querySelector(
      'button[type="submit"]',
    ) as HTMLButtonElement;

    expect(button.disabled).toBe(false);

    component.saving.set(true);
    fixture.detectChanges();
    expect(button.disabled).toBe(true);

    component.saving.set(false);
    component.loadFailed.set(true);
    fixture.detectChanges();
    expect(button.disabled).toBe(true);

    component.loadFailed.set(false);
    fixture.detectChanges();
    expect(button.disabled).toBe(false);
  });
});
