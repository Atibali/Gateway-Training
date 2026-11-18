import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Product, ProductInput } from './product';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private readonly http = inject(HttpClient);
  // Matches the HTTP profile in ProductsApi/Properties/launchSettings.json.
  private readonly apiUrl = 'http://localhost:5024/api/products';

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  createProduct(product: ProductInput): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, product);
  }

  updateProduct(id: number, product: ProductInput): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/${id}`, { id, ...product });
  }

  deleteProduct(id: number): Observable<string> {
    // The existing API responds with a plain-text success message, not JSON.
    return this.http.delete(`${this.apiUrl}/${id}`, { responseType: 'text' });
  }
}
