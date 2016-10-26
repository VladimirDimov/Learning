// Components
import { Component } from 'angular2/core';
import { HomeComponent } from '../app/components/home/home.component';
import { LoginComponent } from '../app/components/account/login/login.component';
import { RegisterComponent } from '../app/components/account/register/register.component';

// Modules
import { RouteConfig, ROUTER_DIRECTIVES } from 'angular2/router';

@Component({
    selector: 'my-app',
    templateUrl: '/app/app.html',
    directives: [ROUTER_DIRECTIVES],
})

@RouteConfig([
    { path: '/', name: 'Home', component: HomeComponent, useAsDefault: true },
    { path: '/account/login', name: 'Login', component: LoginComponent },
    { path: '/account/register', name: 'Register', component: RegisterComponent }
])

export class AppComponent { }