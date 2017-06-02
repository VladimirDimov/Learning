import { Component, OnInit } from '@angular/core';
import { IProduct } from './product';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    moduleId: module.id,
    selector: '',
    templateUrl: 'product-detail.component.html'
})

export class ProductDetailsComponent implements OnInit {

    pageTitle: string = 'Product Details';
    product: IProduct;
    productId: number;

    constructor(private _route: ActivatedRoute, private _router: Router) { }

    ngOnInit(): void {
        this.productId = +this._route.snapshot.params['id'];
    }

    onBack(): void {
        this._router.navigate(['/products']);
    }
}