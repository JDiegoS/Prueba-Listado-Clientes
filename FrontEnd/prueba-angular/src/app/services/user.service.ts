import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import {ClientDetail} from './../interfaces/client-detail.interface'
import {HttpClient, HttpParams} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  backendUrl="https://localhost:7162/api/User/"
  constructor(private http: HttpClient) { }

  getUser(username: string, password: string): Observable<any[]>{
    let params = new HttpParams()
    .set('username', username)
    .set('password', password)
      return this.http.get(this.backendUrl+'GetUser', {params: params}).pipe(
        map(response => {
          let data: any[] = response as any[]
          return data;
        })
      );
      
  }
}
