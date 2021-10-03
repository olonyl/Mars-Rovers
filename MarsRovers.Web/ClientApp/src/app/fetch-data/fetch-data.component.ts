import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  baseUrl: string;
  command: string = "";
  result: string = "";

  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  onClick() {
    this.sendCommand(this.command)
      .subscribe((data: any) => {
        console.log(data);
        this.result = data;
    });
   

  }
  sendCommand(command: string): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}communication`, { command }, this.generateHeaders())
     .pipe(
       map((data: string) => {
         return data;
       }), catchError(error => {
         console.log(error);
         return throwError('Something went wrong!');
       })
     )
  }
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
