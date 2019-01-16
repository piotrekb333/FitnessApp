import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CalculatorService, Calculator } from 'src/app/shared/services/calculator.service';


@Component({
  selector: 'app-bmi-calculator-page',
  templateUrl: './bmi-calculator.component.html',
  styleUrls: ['./bmi-calculator.component.css']
})
export class BMICalculatorComponent {
  public calculatorModel: Calculator
  public BMIResult: string;
  constructor(
    private calculatorService: CalculatorService    
  ) { }
  ngOnInit() {
    this.calculatorModel = {} as Calculator; 
  }
  async Calculate() {
    await this.calculatorService
      .getBMIResult(this.calculatorModel)
      .subscribe(cal => {
        this.BMIResult = cal.bmiResult.toString();
      });
  }
}
