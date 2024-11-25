import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CdbResultado } from '../app/models/cdb-resultado'; 


@Injectable({
  providedIn: 'root'
})
export class CdbService {

  private apiUrl = 'http://localhost:5217/api/InvestmentCalculator/calcular';

  constructor(private http: HttpClient) { }

  calcularCdb(valorInicial: number, meses: number): Observable<CdbResultado> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const body = {
      valorInicial: valorInicial,
      meses: meses
    };

    return this.http.post<CdbResultado>(this.apiUrl, body, { headers: headers });
  }
}
