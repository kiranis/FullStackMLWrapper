import { Component } from '@angular/core';
import { LoanFormComponent } from './loan-form.component';
import { PredictionService } from './prediction.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  template: `<app-loan-form></app-loan-form>`,
  standalone: true,
  imports: [HttpClientModule, LoanFormComponent],
  providers: [PredictionService]
})
export class AppComponent {}