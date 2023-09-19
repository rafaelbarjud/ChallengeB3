import { HttpClient,  HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, retry, throwError } from 'rxjs';
import { Cdbresult } from '../Models/cdbresult';

@Injectable({
  providedIn: 'root'
})
export class CdbserviceService {

  url = 'https://localhost:7279';

  constructor(private httpClient: HttpClient) { }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  getCalculateCdb(amount: number, month: number) {
    console.log(this.url + '/amount/' + amount + '/month/' + month)
    return this.httpClient.get<Cdbresult>(this.url + '/amount/' + amount + '/month/' + month)
      .pipe(
        retry(2),
        catchError((error) => {
          return throwError(() => error);
        })
      )
  }

}
