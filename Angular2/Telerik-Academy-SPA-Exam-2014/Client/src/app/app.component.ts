import { Component, Directive } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { IfAuthenticatedDirective } from './directives/ifAuthenticated.directive';

// Redux
import { NgRedux, DevToolsExtension } from "ng2-redux/lib";
import { RootReducerProvider } from "./redux/reducers";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  constructor(
    private ngRedux: NgRedux<any>,
    private devTools: DevToolsExtension,
    private rootReducerProvider: RootReducerProvider) {
    let middlewares = [];

    let enhancers = [];
    enhancers.push(devTools.enhancer());

    let initialState = {};

    let rootReducer = this.rootReducerProvider.get();

    ngRedux.configureStore(rootReducer, initialState, middlewares, enhancers);

    console.log(ngRedux.getState());
  }

  title = 'app works!';
}
