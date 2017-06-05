import { Injectable } from '@angular/core';
import { HttpRequester } from '../common/http-requester';
import { IRegisterModel } from '../models/register.model';

@Injectable()
export class AuthService {
    constructor(private _httpRequester: HttpRequester) { }

    register(model: IRegisterModel) {
        return this._httpRequester.post<IRegisterModel>('/api/users/register', model)
            .do(data => {
                console.log(data);
            }, err => {
                console.log(err.message);
            });
    }
}