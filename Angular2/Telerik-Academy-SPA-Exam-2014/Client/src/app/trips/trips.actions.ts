import { Injectable } from "@angular/core";
import { ITripCreateModel } from "./create/trip-create.model";
import { TripsService } from "./trips.service";
import { Action } from "redux";
import { NgRedux } from "ng2-redux/lib";

export const TRIP_CREATE_DONE = "TRIP_CREATE";
export const TRIP_CREATE_DOING = "TRIP_CREATE_DOING";
export const TRIP_CREATE_ERROR = "TRIP_CREATE_ERROR";

@Injectable()
export class TripsActions {

    constructor(
        private _tripsService: TripsService,
        private _ngRedux: NgRedux<any>)
    { }

    create(model: ITripCreateModel) {

        this._ngRedux.dispatch({ type: TRIP_CREATE_DOING });
        this._tripsService.create(model)
            .subscribe(res => {
                this._ngRedux.dispatch({ type: TRIP_CREATE_DONE, payload: res });
            }, err => {
                this._ngRedux.dispatch({ type: TRIP_CREATE_ERROR, payload: err });
            })
    }

    all() {

    }

    getById() {

    }
}