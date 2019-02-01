import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ArticlesService, Article } from 'src/app/shared/services/articles.service';


@Component({
  selector: 'app-articler-page',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticlesComponent {
  public articleModel: Article

  constructor(
    private articlesService: ArticlesService    
  ) { }
  ngOnInit() {
    this.articleModel = {} as Article; 
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
