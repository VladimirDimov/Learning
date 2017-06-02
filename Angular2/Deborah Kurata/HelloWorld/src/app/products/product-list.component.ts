import { Component, OnInit } from '@angular/core';
import { IProduct } from './product';
import { ProductService } from './product.service';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'pm-products',
    moduleId: module.id,
    templateUrl: 'product-list.component.html',
    styleUrls: ['product-list.component.css']
})

export class ProductListComponent implements OnInit {
    constructor(private productService: ProductService) {
    }

    ngOnInit(): void {
        this.productService.getProducts()
            .subscribe(data => {
                this.products = data
            }, err => {
                console.log(err);
            });
    }

    pageTitle: string = 'Product List';
    products: IProduct[];
    imageWidth: number = 60;
    imageMargin: number = 15;
    showImage: boolean = false;
    listFilter: string = '';

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    onRatingClicked(message: string) {
        console.log(message);
    }
}