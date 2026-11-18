// Mirrors the Product model returned by the ASP.NET Core Products API.
export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  quantity: number;
}

// The API assigns the id when a new product is created.
export type ProductInput = Omit<Product, 'id'>;
