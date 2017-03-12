import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HeroDetailComponent } from './hero-detail.component';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HeroesComponent } from './heroes.component';
import { DashboardComponent } from './dashboard.component';
import { PageNotFoundComponent } from './page-not-found.component';

@NgModule({
  declarations: [

    AppComponent,

    HeroDetailComponent,
    HeroesComponent,
    DashboardComponent,
    PageNotFoundComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
      },
      {
        path: 'heroes',
        component: HeroesComponent
      },
      {
        path: 'dashboard',
        component: DashboardComponent
      },
      {
        path: 'detail/:id',
        component: HeroDetailComponent
      },
      {
        path: '**',
        component: PageNotFoundComponent
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
