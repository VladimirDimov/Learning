import { Injectable } from '@angular/core';
import { Http, Response, RequestOptionsArgs, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

import { GlobalConstants } from './global-constants';

@Injectable()
export class HttpRequester {

    constructor(private _http: Http) { }

    get(path: string): Observable<Response> {
        return this._http.get(GlobalConstants.serverUrl + path)
            .map((response: Response) => {
                response.json();
            })
            .catch(function (err: Response) {
                debugger;
                return Observable.throw(err.json().error || 'Server error');
            });
    }

    post<T>(path: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        let bodyString = JSON.stringify(body); // Stringify payload
        let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        options = new RequestOptions({ headers: headers }); // Create a request option

        return this._http.post(GlobalConstants.serverUrl + path, bodyString, options)
            .map((res: Response) => res.json())
            .catch((error: any) => {
                debugger;
                return Observable.throw(JSON.parse(error._body) || 'Server error');
            });
    }
}