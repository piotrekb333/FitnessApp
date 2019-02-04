import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { ArticlesService, Article } from 'src/app/shared/services/articles.service';
import { ArticleCategoryService, ArticleCategory } from 'src/app/shared/services/articleCategory.service';
@Component({
  selector: 'app-articles-page',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ArticlesComponent {
  public articleModel: Article
  private articles: Array<Article> = [];
  private articleCategory: Array<ArticleCategory> = [];
  constructor(
    private articlesService: ArticlesService
  ) { }
  ngOnInit() {
    this.articleModel = {} as Article;
    //this.getAllEnabledArticles();
    //this.getAllArticleCategory();
  }


  public getAllEnabledArticles() {
    this.articlesService.getAllEnabledArticles().subscribe((data: Array<Article>) => {
      this.articles = data;
      console.log(data);
    });
  }

  public getAllArticleCategory() {
    this.articlesService.getAllEnabledArticles().subscribe((data: Array<ArticleCategory>) => {
      this.articleCategory = data;
      console.log(data);
    });
  }
}
