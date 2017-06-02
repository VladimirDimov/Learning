import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

// Components
import { WelcomeComponent } from './welcome/welcome.component';
import { ProductFilterPipe } from './products/product-filter.pipe';
import { ProductDetailsComponent } from './products/product-detail.component';
import { AppComponent } from './app.component';
import { ProductListComponent } from './products/product-list.component'
import { StarComponent } from './products/star/star.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    ProductListComponent,
    ProductFilterPipe,
    StarComponent,
    ProductDetailsComponent,
  ],

  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: 'products', component: ProductListComponent },
      { path: 'product/:id', component: ProductDetailsComponent },
      { path: 'welcome', component: WelcomeComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', redirectTo: 'welcome' }
    ]),
  ],

  providers: [],

  bootstrap: [AppComponent]
})

export class AppModule { }
