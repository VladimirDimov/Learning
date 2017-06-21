import { Injectable } from '@angular/core';
import { HttpRequester } from "../common/http-requester";
import { Observable } from "rxjs/Observable";
import { Response } from '@angular/http';
import { IUserInfoModel } from "../models/user-info.model";

@Injectable()
export class UsersService {
    constructor(private _http: HttpRequester) { }

    getUserInfo(): Observable<IUserInfoModel> {
        return Observable.create(observer => {
            this._http.get('/api/users/userInfo').subscribe(data => {
                return observer.next(<IUserInfoModel>data.json());
            }, err => {
                return observer.throw(err.json());
            })
        });
    }
}