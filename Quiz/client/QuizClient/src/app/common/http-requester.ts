import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";
import { CookieService } from "angular2-cookie/core";


@Injectable()
export class HttpRequester {
    constructor(private http: HttpClient, private cookieService: CookieService) {
    }

    get(url: string): Observable<any> {
        let headers = this.getAuthenticationHeader();

        return this.http.get(url, {
            headers: headers
        });
    }

    private getAuthenticationHeader(): HttpHeaders {
        return new HttpHeaders().set('Authorization', 'Bearer ' + this.cookieService.get('access_token'));
    }
}
