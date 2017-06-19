import { Injectable } from '@angular/core';
import { NgRedux } from 'ng2-redux';

export const COUNTER_INCREMENT = 'COUNTER_INCREMENT';
export const COUNTER_DECREMENT = 'COUNTER_DECREMENT';

@Injectable()
export class CounterActions {

    constructor(private ngRedux: NgRedux<any>)
    { }

    public increment() {
        this.ngRedux.dispatch({ type: COUNTER_INCREMENT });
    }

    public decrement() {
        this.ngRedux.dispatch({ type: COUNTER_DECREMENT });
    }
}