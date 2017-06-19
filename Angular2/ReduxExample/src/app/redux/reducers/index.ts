import { combineReducers } from "redux";
import counterReducer from "./counter-reducer";

let rootReducer = <any>combineReducers({
    counterReducer
});

export default rootReducer;