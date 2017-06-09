import { Component, Directive } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { IfAuthenticatedDirective } from './directives/ifAuthenticated.directive';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'app works!';
}
