import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { ArticlesService, Article } from 'src/app/shared/services/articles.service';

@Component({
  selector: 'app-articles-page',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ArticlesComponent {
  public articleModel: Article
  private articles: Array<Article> = [];
  constructor(
    private articlesService: ArticlesService
  ) { }
  ngOnInit() {
    this.articleModel = {} as Article;
    //this.getAllEnabledArticles();
  }


  public getAllEnabledArticles() {
    this.articlesService.getAllEnabledArticles().subscribe((data: Array<Article>) => {
      this.articles = data;
      console.log(data);
    });
  }

  /*
  async Calculate() {
    await this.articleService
      .getBMIResult(this.calculatorModel)
      .subscribe(cal => {
        this.BMIResult = cal.bmiResult.toString();
      });
  }
  */
}
