import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

export interface Newsletter {
  email: string;
}

@Injectable({
  providedIn: 'root'
})

export class NewsletterService {
  constructor(private http: HttpClient) { }

  postNewsletter(newsletter: Newsletter) {
    return this.http.post('https://localhost:44369/api/newsletter', newsletter);
  }
}
