import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { APP_CONFIG, AppConfig } from 'src/app/app-config.module';
export interface ArticleCategory {
  name: string;
}

@Injectable({
  providedIn: 'root'
})

export class ArticleCategoryService {
  constructor(private http: HttpClient, @Inject(APP_CONFIG) private config: AppConfig) { }
 
  getAllArticleCategory() {
    return this.http.get(this.config.apiEndpoint+'/articleCategory');
  }

}
