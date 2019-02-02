import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ArticleComponent } from './article.component';
import { SharedModule } from 'src/app/shared/shared.module'
import { ArticleRoutingModule } from './article-routing.module';
import { ArticlesService } from 'src/app/shared/services/articles.service';

@NgModule({
  imports: [
    SharedModule,
    ArticleRoutingModule
  ],
  declarations: [
    ArticleComponent
  ]
})
export class ArticleModule { }
