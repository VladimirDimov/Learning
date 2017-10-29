import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { HOME_ROUTE, LOGIN_ROUTE, REGISTER_ROUTE } from '../common/routes'
import { CookieService } from 'angular2-cookie/core';
import { Router } from '@angular/router';
import { SharedService } from '../common/shared.service';

const ACCESSS_TOKEN_COOKIE: string = 'access_token';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})

export class NavbarComponent implements OnInit {

  constructor(
    private cookieService: CookieService,
    private router: Router,
    private sharedService: SharedService) { }

  ngOnInit() {

  }

  @Input() isAuthenticated: boolean;

  HOME_ROUTE = HOME_ROUTE;
  LOGIN_ROUTE = LOGIN_ROUTE;
  REGISTER_ROUTE = REGISTER_ROUTE;

  @Output() onLogInOutEmitter = new EventEmitter();

  onSignOut() {
    this.cookieService.remove(ACCESSS_TOKEN_COOKIE);
    this.sharedService.refreshIsAuthenticated();
    this.router.navigateByUrl(HOME_ROUTE);
  }
}
