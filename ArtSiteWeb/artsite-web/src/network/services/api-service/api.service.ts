import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = "http://localhost:5000/"

  constructor(private http: HttpClient) { }

  get<T>(url: String): Observable<T>{
    return this.http.get<T>(this.baseUrl + url);
  }

  post<T>(url: String, body: object): Observable<T>{
    return this.http.post<T>(this.baseUrl + url, body);
  }
}
