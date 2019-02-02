import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { APP_CONFIG, AppConfig } from 'src/app/app-config.module';
export interface Article {
  email: string;
}

@Injectable({
  providedIn: 'root'
})

export class ArticlesService {
  constructor(private http: HttpClient, @Inject(APP_CONFIG) private config: AppConfig){}

  postArticle(article: Article) {
    return this.http.post('${this.config.apiEndpoint}/articles', article);
  }

  getAllEnabledArticles() {
    return this.http.get('${this.config.apiEndpoint}/articles');
  }

}
