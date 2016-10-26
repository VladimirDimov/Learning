import { Injectable, Inject } from 'angular2/core';
import { Http, Headers } from 'angular2/http';
import 'rxjs/add/operator/map';

@Injectable()
export class AppService {
    constructor(private _http: Http) {
        // Empty constructor
    }

    getPeople() {
        return this._http.get('http://localhost:51523/api/home')
            .map(x => x.json());
    }

    addPerson(name: string) {
        var data = {
            Name: name
        };

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this._http.post(
            'http://localhost:51523/api/home',
            JSON.stringify(data), {
                headers: headers
            });
    }
}