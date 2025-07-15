import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface InputModel {
  income: number;
  age: number;
  creditScore: number;
}

@Injectable({
  providedIn: 'root'
})
export class PredictionService {
  private apiUrl = 'http://localhost:5000/api/predict';

  constructor(private http: HttpClient) {}

  predict(input: InputModel): Observable<any> {
    return this.http.post<any>(this.apiUrl, input);
  }
}