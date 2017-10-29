import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from 'selenium-webdriver/http';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { RouterProvider } from './common/routes';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { TextboxTemplateComponent } from './common/form-templates/textbox-template/textbox-template.component';

import { UserService } from './services/user.service';

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
    RouterProvider.routerModule
  ],
  providers: [FormBuilder, UserService],
  bootstrap: [AppComponent]
})

export class AppModule { }
