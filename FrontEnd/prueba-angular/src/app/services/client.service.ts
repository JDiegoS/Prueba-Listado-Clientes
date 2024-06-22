import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import {ClientDetail} from './../interfaces/client-detail.interface'

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  backendUrl="https://localhost:7162/api/Client/"
  constructor(private http: HttpClient) { }

  getClients(): Observable<ClientDetail[]>{
      return this.http.get(this.backendUrl+'GetClients').pipe(
        map(response => {
          let data: ClientDetail[] = response as ClientDetail[]
          return data;
        })
      );
      
  }

  addClient(name: string, location: string, phone: string, comments: string ): Observable<string>{
    let params = new HttpParams()
    .set('name', name)
    .set('location', location)
    .set('phone', phone)
    .set('comments', comments)
    return this.http.get(this.backendUrl+'AddClient', {params: params}).pipe(
        map(response => {
        let data: string = response as string
        console.log(response)
        return data;
      })
    );

    
    
  }

  DeleteClient(name: string): Observable<string>{
    let params = new HttpParams()
    .set('name', name)
    return this.http.get(this.backendUrl+'DeleteClient', {params: params}).pipe(
        map(response => {
        let data: string = response as string
        console.log(response)
        return data;
      })
    );
  }
}
