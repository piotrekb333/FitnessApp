import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { ArticlesService, Article } from 'src/app/shared/services/articles.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-article-page',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ArticleComponent {
  public articleModel: Article
  private id: string;
  constructor(
    private articlesService: ArticlesService,
    private route: ActivatedRoute
  ) {
    this.id=this.route.snapshot.params.id;
  }
  ngOnInit() {
    this.articleModel = {} as Article;
    this.getArticleById(this.id);
  }


  public getArticleById(articleId: string) {
    this.articlesService.getArticleById(articleId).subscribe((data: Article) => {
      this.articleModel = data;
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
