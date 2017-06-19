import { Component } from '@angular/core';
import { NgRedux, DevToolsExtension, select } from "ng2-redux/lib";
import { CounterActions } from "./redux/actions/counter-actions";
import rootReducer from './redux/reducers';
import { Observable } from "rxjs/Observable";
import counterReducer from "./redux/reducers/counter-reducer";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'app works!';

  @select(s => {
    return <number>s.counterReducer;
  }) counter: Observable<number>;

  constructor(
    private ngRedux: NgRedux<any>,
    private devTools: DevToolsExtension,
    public actions: CounterActions) {

    let middlewares = [];

    let enhancers = [];
    enhancers.push(devTools.enhancer());

    let initialState = {};

    ngRedux.configureStore(rootReducer, initialState, middlewares, enhancers);
  }

  increment() {
    console.log(this.counter);

    console.log(this.ngRedux.getState().counterReducer);

    return this.counter;
  }
}
