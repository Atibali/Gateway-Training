import { Routes } from '@angular/router';
import { ProductDetails } from './product-details/product-details';
import { ProductForm } from './product-form/product-form';
import { ProductList } from './product-list/product-list';

export const routes: Routes = [
  { path: '', component: ProductList, title: 'Products' },
  { path: 'products/new', component: ProductForm, title: 'Add product' },
  { path: 'products/:id/edit', component: ProductForm, title: 'Edit product' },
  { path: 'products/:id', component: ProductDetails, title: 'Product details' },
  { path: '**', redirectTo: '' },
];
