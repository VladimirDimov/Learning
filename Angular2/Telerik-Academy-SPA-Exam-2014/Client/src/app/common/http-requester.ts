import { Injectable } from '@angular/core';
import { Http, Response, RequestOptionsArgs, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

import { GlobalConstants } from './global-constants';
import { CookieService } from "angular2-cookie/services";

@Injectable()
export class HttpRequester {

    constructor(private _http: Http, private _cookieService: CookieService)
    { }

    get(path: string, options?: RequestOptionsArgs): Observable<Response> {
        let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        headers = this.setAuthHeader(headers);
        options = options || new RequestOptions({ headers: headers }); // Create a request option

        return this._http.get(GlobalConstants.serverUrl + path, options)
            .map((response: Response) => response)
            .catch(function (err: Response) {
                return Observable.throw(err.json().error || 'Server error');
            });
    }

    post<T>(path: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        let bodyString = JSON.stringify(body); // Stringify payload
        let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        this.setAuthHeader(headers);
        options = options || new RequestOptions({ headers: headers }); // Create a request option

        return this._http.post(GlobalConstants.serverUrl + path, bodyString, options)
            .map((res: Response) => {
                return res;
            })
            .catch((error: any) => {
                // debugger;
                var messages = [];
                var errorBody = JSON.parse(error._body);
                if (errorBody.modelState) {
                    for (let m in errorBody.modelState) {
                        messages.push(errorBody.modelState[m].join('\r\n'));
                    }
                }

                if (errorBody.error_description) {
                    messages.push(errorBody.error_description);
                }

                var err = Observable.throw(messages);

                return err;
            });
    }

    postUrlEncoded(path: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        options = options || new RequestOptions({ headers: headers });

        return this._http.post(GlobalConstants.serverUrl + path, body, options)
            .map((res: Response) => {
                return res;
            })
            .catch((error: any) => {
                // debugger;
                var messages = [];
                var errorBody = JSON.parse(error._body);
                if (errorBody.modelState) {
                    for (let m in errorBody.modelState) {
                        messages.push(errorBody.modelState[m].join('\r\n'));
                    }
                }

                if (errorBody.error_description) {
                    messages.push(errorBody.error_description);
                }

                var err = Observable.throw(messages);

                return err;
            });
    }

    private setAuthHeader(headers: Headers): Headers {
        var token = this._cookieService.get(GlobalConstants.BearerTokenCookie);
        if (token) {
            headers.append('Authorization', 'Bearer ' + token);
        }

        return headers;
    }
}