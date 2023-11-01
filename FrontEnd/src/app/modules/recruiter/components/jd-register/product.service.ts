import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions ={
  headers:new HttpHeaders({'Content-Type':'Application/json'})
}
// const apiUrl = 'http://localhost:8080/api/Companys/get-all';
const apiUrl = 'http://localhost:8080/api/Recuirter/get-all';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient:HttpClient) { }

  getAll():Observable<any[]>{
    return this.httpClient.get<any[]>(apiUrl).pipe(
    )
  }
}
