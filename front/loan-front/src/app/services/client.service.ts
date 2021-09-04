import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Client } from '../Models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  apiUrl: string = '';
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  clients: Client[] = [];

  constructor(private http: HttpClient) { }

  createClient(data: Client): Observable<any> {
    return this.http.post(this.apiUrl, data)
      .pipe(catchError(this.error))
  }

  getClients() {
    return this.http.get<Client[]>(this.apiUrl)
      .toPromise()
      .then((res: any) => {
        res.data.map((c: Client) => {
          return c;
        })
      })
      .catch(this.error);
  }

  updateClient(data: Client) {
    return this.http.put(this.apiUrl, data)
      .pipe(
        catchError(this.error)
      )
  }

  deleteClient(id: number): Observable<any> {
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
