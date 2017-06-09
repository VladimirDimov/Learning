import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpRequester } from '../common/http-requester';
import { IRegisterModel } from '../models/register.model';
import { ILoginModel } from "../models/login-model";
import { Response } from '@angular/http';
import { ILoginResponse } from "../models/login-response.model";
import { CookieService } from "angular2-cookie/core";
import { GlobalConstants } from "../common/global-constants";
import { Observable } from "rxjs/Observable";

@Injectable()
export class AuthService {
    constructor(private _httpRequester: HttpRequester, private _cookieService: CookieService) { }

    @Output() onLoginEvent: EventEmitter<any> = new EventEmitter();
    @Output() onLogoutEvent: EventEmitter<any> = new EventEmitter();

    register(model: IRegisterModel): Observable<Response> {
        return this._httpRequester.post<IRegisterModel>('/api/users/register', model)
            .map((data: Response) => {
                return data;
            })
            .catch(err => {
                return Observable.throw(err.join('\r\n'));
            })
    }

    login(model: any): Observable<Response> {
        model.grant_type = 'password';
        var data = 'grant_type=password&username=' + model.username + '&password=' + model.password;

        return this._httpRequester.postUrlEncoded('/api/users/login', data)
            .do(data => {
                var model = <ILoginResponse>data.json();
                this._cookieService.put(GlobalConstants.BearerTokenCookie, model.access_token);
                this.onLoginEvent.emit();
                return null;
            })
            .catch(err => {
                return Observable.throw(err.join('\r\n'));
            });
    }

    logout(): Observable<Response> {

        return new Observable(observer => {
            try {
                this._cookieService.remove(GlobalConstants.BearerTokenCookie);
                this.onLogoutEvent.emit();
                observer.next();
            } catch (error) {
                observer.error('Some error occurred while logging out.')
            }
        });
    }
}