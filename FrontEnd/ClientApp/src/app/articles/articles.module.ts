import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ArticlesComponent } from './articles.component';
import { SharedModule } from 'src/app/shared/shared.module'
import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticlesService } from 'src/app/shared/services/articles.service';

@NgModule({
  imports: [
    SharedModule,
    ArticlesRoutingModule
  ],
  declarations: [
    ArticlesComponent
  ]
})
export class ArticlesModule { }
