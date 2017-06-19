import { IStatsModel } from "./stats.model";
import { HttpRequester } from "../common/http-requester";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";

@Injectable()
export class StatsService {
    constructor(
        private _httpRequester: HttpRequester)
    { }

    getAll(): Observable<IStatsModel> {
        return this._httpRequester.get('/api/stats')
            .map(x => {
                let data = <IStatsModel>x.json();
                return data;
            })
            .catch(err => err);
    }
}