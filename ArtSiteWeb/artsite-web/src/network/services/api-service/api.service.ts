import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = "https://localhost:7095/"

  constructor(private http: HttpClient) { }

  get<T>(url: String){
    return this.http.get<T>(this.baseUrl + url);
  }


}
