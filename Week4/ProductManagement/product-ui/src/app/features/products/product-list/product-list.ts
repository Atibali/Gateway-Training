import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Product } from '../product.model';
import { ProductService } from '../product';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css'
})
export class ProductList implements OnInit {

  private productService = inject(ProductService);

  products = signal<Product[]>([]);

  isLoading = signal(false);

  errorMessage = signal('');

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.isLoading.set(true);
    this.errorMessage.set('');

    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products.set(data);
        this.isLoading.set(false);
      },

      error: (error) => {
        console.error('Error fetching products:', error);

        this.errorMessage.set('Unable to load products.');
        this.isLoading.set(false);
      }
    });
  }
}