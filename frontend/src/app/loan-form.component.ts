import { Component } from '@angular/core';
import { PredictionService, InputModel } from './prediction.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-loan-form',
  templateUrl: './loan-form.component.html',
  standalone: true,
  imports: [FormsModule]
})
export class LoanFormComponent {
  input: InputModel = { income: 0, age: 0, creditScore: 0 };
  result: string | null = null;

  constructor(private predictionService: PredictionService) {}

  submit() {
    this.predictionService.predict(this.input).subscribe(res => {
      this.result = res.result;
    });
  }
}