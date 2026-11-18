import { Component, OnInit, inject, signal } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ProductService } from '../core/product.service';

@Component({
  selector: 'app-product-form',
  imports: [
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule,
    ReactiveFormsModule,
    RouterLink,
  ],
  templateUrl: './product-form.html',
  styleUrl: './product-form.scss',
})
export class ProductForm implements OnInit {
  private readonly formBuilder = inject(FormBuilder);
  private readonly productService = inject(ProductService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);

  readonly form = this.formBuilder.nonNullable.group({
    name: ['', [Validators.required, Validators.maxLength(100)]],
    description: ['', [Validators.maxLength(500)]],
    price: [0.01, [Validators.required, Validators.min(0.01)]],
    quantity: [0, [Validators.required, Validators.min(0), Validators.pattern(/^\d+$/)]],
  });

  productId = signal<number | null>(null);
  loading = signal(false);
  loadFailed = signal(false);
  saving = signal(false);
  errorMessage = signal('');

  get isEditing(): boolean {
    return this.productId() !== null;
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id === null) {
      return;
    }

    const productId = Number(id);
    if (!Number.isInteger(productId) || productId <= 0) {
      this.errorMessage.set('The product id in this URL is invalid.');
      this.loadFailed.set(true);
      return;
    }

    this.productId.set(productId);
    this.loading.set(true);
    this.productService.getProduct(productId).subscribe({
      next: (product) => {
        this.form.patchValue({
          name: product.name,
          description: product.description,
          price: product.price,
          quantity: product.quantity,
        });
        this.loading.set(false);
      },
      error: () => {
        this.errorMessage.set('Could not load this product. It may have been removed.');
        this.loadFailed.set(true);
        this.loading.set(false);
      },
    });
  }

  save(): void {
    this.form.markAllAsTouched();
    if (this.form.invalid || this.saving() || this.loading() || this.loadFailed()) {
      return;
    }

    this.saving.set(true);
    this.errorMessage.set('');
    const productId = this.productId();
    const product = this.form.getRawValue();
    const request =
      productId === null
        ? this.productService.createProduct(product)
        : this.productService.updateProduct(productId, product);

    request.subscribe({
      next: () => void this.router.navigateByUrl('/'),
      error: () => {
        this.errorMessage.set(
          `Could not ${this.isEditing ? 'update' : 'create'} the product. Please try again.`,
        );
        this.saving.set(false);
      },
    });
  }
}
