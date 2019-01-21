
import { NgModule } from '@angular/core';
import { AppConfigModule } from './app-config.module';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HomeModule } from './home/home.module';
import { FooterComponent } from './shared/layout/footer.component';
import { HeaderComponent } from './shared/layout/header.component';
import { SharedModule } from './shared/shared.module'
import { AppRoutingModule } from './app-routing.module';
import { BMICalculatorModule } from './calculators/bmi-calculator/bmi-calculator.module';
import { WHRCalculatorModule } from './calculators/whr-calculator/whr-calculator.module';
import { VideosModule } from './videos/videos.module';
@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    AppConfigModule,
    BrowserModule,
    SharedModule,
    HomeModule,
    AppRoutingModule,
    BMICalculatorModule,
    WHRCalculatorModule,
    VideosModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
