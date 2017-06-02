import { Component } from '@angular/core';
import { IProduct } from './product';

@Component({
    moduleId: module.id,
    selector: '',
    templateUrl: 'product-detail.component.html'
})

export class ProductDetails {
    pageTitle: 'Product Details';
    product: IProduct;
}