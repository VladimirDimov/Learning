import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
// import { RouterModule } from '@angular/router';

// Components
import { ProductFilterPipe } from './products/product-filter.pipe';
import { ProductDetails } from './products/product-detail.component';
import { AppComponent } from './app.component';
import { ProductListComponent } from './products/product-list.component'
import { StarComponent } from './products/star/star.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductFilterPipe,
    StarComponent,
    ProductDetails
  ],

  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],

  providers: [],

  bootstrap: [AppComponent]
})

export class AppModule { }
