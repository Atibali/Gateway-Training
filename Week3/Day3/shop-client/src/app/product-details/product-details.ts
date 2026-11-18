import { Component, OnInit, inject, signal } from '@angular/core';
import { CurrencyPipe } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Product } from '../core/product';
import { ProductService } from '../core/product.service';

@Component({
  selector: 'app-product-details',
  imports: [CurrencyPipe, MatButtonModule, MatCardModule, MatProgressSpinnerModule, RouterLink],
  templateUrl: './product-details.html',
  styleUrl: './product-details.scss',
})
export class ProductDetails implements OnInit {
  private readonly productService = inject(ProductService);
  private readonly route = inject(ActivatedRoute);

  product = signal<Product | undefined>(undefined);
  loading = signal(true);
  errorMessage = signal('');

  ngOnInit(): void {
    // Route parameters arrive as strings, so validate before calling the typed API.
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!Number.isInteger(id) || id <= 0) {
      this.errorMessage.set('The product id in this URL is invalid.');
      this.loading.set(false);
      return;
    }

    this.productService.getProduct(id).subscribe({
      next: (product) => {
        this.product.set(product);
        this.loading.set(false);
      },
      error: () => {
        this.errorMessage.set('Could not load this product. It may have been removed.');
        this.loading.set(false);
      },
    });
  }
}
