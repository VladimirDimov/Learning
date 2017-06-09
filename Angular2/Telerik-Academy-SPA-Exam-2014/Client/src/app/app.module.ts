import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from "./home/home.component";
import { UserInfoComponent } from "./userInfo/user-info.component";

import { HttpRequester } from './common/http-requester';
import { GlobalConstants } from './common/global-constants';
import { AuthService } from './services/auth-service';
import { ValidationService } from './common/validation-service';

import { ToastrModule } from 'toastr-ng2';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { IfAuthenticatedDirective } from "./directives/ifAuthenticated.directive";
import { UsersService } from "./services/users.service";

@NgModule({
  declarations: [
    // Components
    AppComponent,
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    UserInfoComponent,
    // Directives
    IfAuthenticatedDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'userInfo', component: UserInfoComponent }
    ])
  ],
  providers: [HttpRequester, GlobalConstants, AuthService, ValidationService, CookieService, UsersService],
  exports: [IfAuthenticatedDirective],
  bootstrap: [AppComponent],
})
export class AppModule { }
