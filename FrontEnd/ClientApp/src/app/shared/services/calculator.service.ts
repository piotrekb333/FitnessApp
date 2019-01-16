import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

export interface Calculator {
  weight: number;
  height: number;
}

export interface CalculatorResult {
  BMIResult: number;
}

@Injectable({
  providedIn: 'root'
})

export class CalculatorService {
  constructor(private http: HttpClient) { }

  getBMIResult(cal: Calculator): Observable<CalculatorResult> {

    const params = new HttpParams()
      .set('weight', cal.weight.toString())
      .set('height', cal.height.toString());
    debugger;
    return this.http.get<CalculatorResult>('http://localhost:44369/api/calculator/bmi', {params});
  }
}
