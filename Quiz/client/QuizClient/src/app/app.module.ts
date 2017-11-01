import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { HomeService } from './home/home.service';
import { HttpRequester } from './common/http-requester';
import { NoopInterceptor } from './common/interceptors/http-interceptor';
import { CreateQuizComponent } from './create-quiz/create-quiz.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    TextboxTemplateComponent,
    CreateQuizComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    RouterProvider.routerModule,
    HttpClientModule
  ],
  providers: [FormBuilder, UserService, Endpoints, CookieService, HomeService, HttpRequester,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: NoopInterceptor,
      multi: true,
    }],
  bootstrap: [AppComponent]
})

export class AppModule { }
