import { Component } from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import { HomeComponent } from './home.component';
import { AboutComponent } from './about.component';

@Component({
    selector: 'my-app',
    template: `
                <nav>
		            <a [routerLink]="['Home']">Home</a>
		            <a [routerLink]="['About']">About</a>
	            </nav>

                <div class="main">
                    <router-outlet></router-outlet>
                </div>
              `,
    providers: [ROUTER_PROVIDERS],
    directives: [HomeComponent, AboutComponent, ROUTER_DIRECTIVES]
})

@RouteConfig([
    { path: '/', component: HomeComponent, name: 'Home', useAsDefault: true },
    { path: '/about', component: AboutComponent, name: 'About' },
])

export class AppComponent { }