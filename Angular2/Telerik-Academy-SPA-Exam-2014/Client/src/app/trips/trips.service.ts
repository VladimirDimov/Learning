import { Injectable } from "@angular/core";
import { HttpRequester } from "../common/http-requester";
import { ITripCreateModel } from "./create/trip-create.model";
import { Observable } from "rxjs/Observable";

@Injectable()
export class TripsService {
    constructor(
        private _httpRequester: HttpRequester)
    { }

    create(model: ITripCreateModel): Observable<any> {
        return this._httpRequester.post('/api/trips', model)
            .map(res => res.json())
            .catch(err => {
                return Observable.throw(err);
            });
    }
}