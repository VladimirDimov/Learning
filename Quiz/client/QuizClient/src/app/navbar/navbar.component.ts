import { Component, OnInit } from '@angular/core';
import { HOME_ROUTE, LOGIN_ROUTE, REGISTER_ROUTE } from '../common/routes'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  HOME_ROUTE = HOME_ROUTE;
  LOGIN_ROUTE = LOGIN_ROUTE;
  REGISTER_ROUTE = REGISTER_ROUTE;
}
