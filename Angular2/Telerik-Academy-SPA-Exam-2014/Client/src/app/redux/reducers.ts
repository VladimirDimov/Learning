
import { combineReducers } from "redux";
import StatsReducer from "../stats/stats.reducer";
import { Injectable } from "@angular/core";
import TripsReducer from "../trips/trips.reducer";

@Injectable()
export class RootReducerProvider {
    constructor(private statsReducer: StatsReducer, private tripsReducer: TripsReducer)
    { }

    get(): any {
        return <any>combineReducers({
            statsReducer: this.statsReducer.reduce,
            tripsReducer: this.tripsReducer.reduce
        });
    }
}