
import { Injectable } from "@angular/core";
import { Action } from "redux";
import { TRIP_CREATE_DONE, TRIP_CREATE_DOING, TRIP_CREATE_ERROR } from "./trips.actions";

let initialState = {
    isCreatingTrip: false,
    error: null,
}

function tripCreateDoing(state, action) {
    return Object.assign({}, state, { isCreatingTrip: true });
}

function tripCreateDone(state, action) {
    return Object.assign({}, state, { newTrip: (<any>action).payload, isCreatingTrip: false });
}

function tripCreateError(state, action) {
    debugger;
    return Object.assign({}, state, { error: action.payload });
}

@Injectable()
export default class TripsReducer {

    public reduce(state = initialState, action: Action) {
        switch (action.type) {
            case TRIP_CREATE_DOING:
                return tripCreateDoing(state, action);

            case TRIP_CREATE_DONE:
                return tripCreateDone(state, action);

            case TRIP_CREATE_ERROR:
                return tripCreateError(state, action);

            default:
                return state;
        }
    }
}