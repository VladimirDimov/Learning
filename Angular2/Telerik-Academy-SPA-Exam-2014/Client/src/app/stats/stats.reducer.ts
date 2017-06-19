import { Action } from "redux";
import { GET_ALL } from "./stats.actions";
// import { StatsService } from "./stats.service";
import { Injectable } from "@angular/core";
import { IStatsModel  } from "./stats.model";

@Injectable()
export default class StatsReducer {

    // constructor(
    //     private statsService: StatsService)
    // { }

    public reduce(state = {}, action: Action) {
        switch (action.type) {
            case GET_ALL:
                return Object.assign({}, (<any>action).data);

            default:
                return state;
        }
    }
}