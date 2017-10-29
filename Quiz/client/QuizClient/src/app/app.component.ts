import { Component, OnInit } from '@angular/core';
import { CookieService } from 'angular2-cookie/core';
import { SharedService } from './common/shared.service';

const ACCESSS_TOKEN_COOKIE: string = 'access_token';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [SharedService]
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private cookieService: CookieService, private sharedService: SharedService) { }

  ngOnInit(): void {
    this.sharedService.refreshLogin.subscribe(this.onLogInOut);
    this.onLogInOut(this.sharedService);
  }

  onLogInOut(sharedService: SharedService) {
    sharedService.refreshIsAuthenticated();
  }
}
