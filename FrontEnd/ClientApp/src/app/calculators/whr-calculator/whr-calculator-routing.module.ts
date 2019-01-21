import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WHRCalculatorComponent } from './whr-calculator.component';


const routes: Routes = [
  {
    path: 'calculators/whr-calculator',
    component: WHRCalculatorComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WHRCalculatorRoutingModule { }
