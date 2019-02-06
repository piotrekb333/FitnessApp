import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { APP_CONFIG, AppConfig } from 'src/app/app-config.module';

export interface Product {
  id: number;
  name: string;
  calories: number;
  carbohydrates: number;
  protein: number;
  fat: number;
}

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  constructor(private http: HttpClient, @Inject(APP_CONFIG) private config: AppConfig) { }

  postProduct(product: Product) {
    return this.http.post(this.config.apiEndpoint +'/product', product);
  }

  putProduct(product: Product) {
    return this.http.put(this.config.apiEndpoint + '/product', product);
  }

  getUserProducts() {
    return this.http.get(this.config.apiEndpoint + '/product/productsGroupsByUserId');
  }

}
