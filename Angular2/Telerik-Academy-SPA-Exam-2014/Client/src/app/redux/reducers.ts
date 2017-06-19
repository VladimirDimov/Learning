
import { combineReducers } from "redux";
import StatsReducer from "../stats/stats.reducer";
import { Injectable } from "@angular/core";

@Injectable()
export class RootReducerProvider {
    constructor(private statsReducer: StatsReducer)
    { }

    get(): any {
        return <any>combineReducers({
            statsReducer: this.statsReducer.reduce
        });
    }
}