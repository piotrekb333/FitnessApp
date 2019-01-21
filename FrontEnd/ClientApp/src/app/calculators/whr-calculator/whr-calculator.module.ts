import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { WHRCalculatorComponent } from './whr-calculator.component';
import { SharedModule } from 'src/app/shared/shared.module'
import { WHRCalculatorRoutingModule } from './whr-calculator-routing.module';
import { CalculatorService } from 'src/app/shared/services/calculator.service';

@NgModule({
  imports: [
    SharedModule,
    WHRCalculatorRoutingModule
  ],
  declarations: [
    WHRCalculatorComponent
  ]
})
export class WHRCalculatorModule { }
