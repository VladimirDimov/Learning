import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Endpoints } from '../common/endpoints';

@Injectable()
export class UserService {

  constructor(private http: HttpClient, private endpoints: Endpoints) { }

  register(model: object): Observable<any> {
    return this.http.post(this.endpoints.register, JSON.stringify(model), {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .set('Data-Type', 'application/json'),
      responseType: 'text'
    });
  }

  login(model: any): Observable<any> {
    let urlEncodedBody: string = `username=${model.username}&grant_type=${model.grant_type}&password=${model.password}`;
    return this.http.post(this.endpoints.login, urlEncodedBody, {
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
    });
  }
}
