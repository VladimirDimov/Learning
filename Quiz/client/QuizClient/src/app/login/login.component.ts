import { Component, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CookieService } from 'angular2-cookie/core';

import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { HOME_ROUTE } from '../common/routes';
import { SharedService } from '../common/shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private userService: UserService,
    private cookieService: CookieService,
    private router: Router,
    private sharedService: SharedService) { }

  ngOnInit() {
  }

  form: FormGroup = new FormGroup({
    username: new FormControl('', Validators.required),
    grant_type: new FormControl('password'),
    password: new FormControl('', Validators.required)
  });

  submit(model: object) {
    this.userService.login(model).subscribe(
      res => {
        this.cookieService.put('access_token', res.access_token);
        this.router.navigateByUrl(HOME_ROUTE);
        this.sharedService.refreshIsAuthenticated();
      },
      err => {
        console.log(err);
      }
    )
  }
}
