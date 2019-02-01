import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

export interface Article {
  email: string;
}

@Injectable({
  providedIn: 'root'
})

export class ArticlesService {
  constructor(private http: HttpClient) { }

  postNewsletter(article: Article) {
    return this.http.post('https://localhost:44369/api/newsletter', article);
  }
}
