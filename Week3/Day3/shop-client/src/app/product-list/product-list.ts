import { Component, OnInit, inject, signal } from '@angular/core';
import { CurrencyPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Product } from '../core/product';
import { ProductService } from '../core/product.service';

@Component({
  selector: 'app-product-list',
  imports: [CurrencyPipe, MatButtonModule, MatCardModule, MatProgressSpinnerModule, RouterLink],
  templateUrl: './product-list.html',
  styleUrl: './product-list.scss',
})
export class ProductList implements OnInit {
  private readonly productService = inject(ProductService);

  products = signal<Product[]>([]);
  loading = signal(true);
  errorMessage = signal('');

  ngOnInit(): void {
    this.loadProducts();
  }

  // Keep the list refreshable after create, update, and delete operations.
  loadProducts(): void {
    this.loading.set(true);
    this.errorMessage.set('');
    this.productService.getProducts().subscribe({
      next: (products) => {
        this.products.set(products);
        this.loading.set(false);
      },
      error: () => {
        this.errorMessage.set('Could not load products. Check that the .NET API is running.');
        this.loading.set(false);
      },
    });
  }

  deleteProduct(product: Product): void {
    if (!window.confirm(`Delete "${product.name}"?`)) {
      return;
    }

    this.productService.deleteProduct(product.id).subscribe({
      next: () => this.loadProducts(),
      error: () => {
        this.errorMessage.set(`Could not delete "${product.name}". Please try again.`);
      },
    });
  }
}
