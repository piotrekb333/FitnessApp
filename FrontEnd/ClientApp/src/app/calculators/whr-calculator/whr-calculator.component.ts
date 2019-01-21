import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CalculatorService, Calculator } from 'src/app/shared/services/calculator.service';


@Component({
  selector: 'app-whr-calculator-page',
  templateUrl: './whr-calculator.component.html',
  styleUrls: ['./whr-calculator.component.css']
})
export class WHRCalculatorComponent {
  public calculatorModel: Calculator
  public WHRResult: string;
  constructor(
    private calculatorService: CalculatorService    
  ) { }
  ngOnInit() {
    this.calculatorModel = {} as Calculator; 
  }
  async Calculate() {
    debugger;
    await this.calculatorService
      .getWHRResult(this.calculatorModel)
      .subscribe(cal => {
        this.WHRResult = cal.whrResult.toString();
      });
  }
}
