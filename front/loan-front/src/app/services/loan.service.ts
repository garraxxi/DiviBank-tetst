import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Loan } from '../Models/loan';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  apiUrl: string = '';
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  createLoan(data: Loan): Observable<any> {
    return this.http.post(this.apiUrl, data)
      .pipe(catchError(this.error))
  }

  getLoans() {
    return this.http.get(this.apiUrl);
  }

  updateLoan(data: Loan) {
    return this.http.put(this.apiUrl, data)
      .pipe(
        catchError(this.error)
      )
  }

  deleteLoan(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`)
      .pipe(
        catchError(this.error)
      )
  }

  error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
