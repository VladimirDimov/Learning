import { Injectable } from "@angular/core";
import { NgRedux } from 'ng2-redux';
import { StatsService } from "./stats.service";

export const GET_ALL = 'GET_ALL';

@Injectable()
export class StatsActions {
    constructor(
        private ngRedux: NgRedux<any>,
        private _statsService: StatsService)
    { }

    public get() {
        this._statsService.getAll()
            .subscribe(data => {
                this.ngRedux.dispatch({
                    type: GET_ALL,
                    data
                });
            })
    }
}