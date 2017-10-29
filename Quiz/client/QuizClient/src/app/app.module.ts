import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterProvider } from './common/routes';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { TextboxTemplateComponent } from './common/form-templates/textbox-template/textbox-template.component';

import { UserService } from './services/user.service';
import { Endpoints } from './common/endpoints';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { SharedService } from './common/shared.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    TextboxTemplateComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    RouterProvider.routerModule,
    HttpClientModule
  ],
  providers: [FormBuilder, UserService, Endpoints, CookieService],
  bootstrap: [AppComponent]
})

export class AppModule { }
