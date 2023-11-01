import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
   providedIn: 'root'
})
export class JdDataService {
   url = "http://localhost:8080/api/Recuirter/get-all?page=10"

   constructor(private http: HttpClient) {
     
   }
   getAllJd(){
      return this.http.get(this.url);
   }
}
