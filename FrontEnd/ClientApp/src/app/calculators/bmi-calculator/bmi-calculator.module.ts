import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { BMICalculatorComponent } from './bmi-calculator.component';
import { SharedModule } from 'src/app/shared/shared.module'
import { BMICalculatorRoutingModule } from './bmi-calculator-routing.module';
import { CalculatorService } from 'src/app/shared/services/calculator.service';

@NgModule({
  imports: [
    SharedModule,
    BMICalculatorRoutingModule
  ],
  declarations: [
    BMICalculatorComponent
  ]
})
export class BMICalculatorModule { }
