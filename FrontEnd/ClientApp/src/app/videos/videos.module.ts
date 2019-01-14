import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { VideosComponent } from './videos.component';
import { SharedModule } from '../shared/shared.module';
import { VideosRoutingModule } from './videos-routing.module';

@NgModule({
  imports: [
    SharedModule,
    VideosRoutingModule
  ],
  declarations: [
    VideosComponent
  ]
})
export class VideosModule { }
