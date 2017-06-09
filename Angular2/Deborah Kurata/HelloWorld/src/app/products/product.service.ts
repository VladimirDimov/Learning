import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

import { IProduct } from './product'

@Injectable()
export class ProductService {

    private _productsJsonUrl = 'src/data/products.json';

    constructor(private _http: Http) { }

    getProducts(): Observable<IProduct[]> {
        return this._http
            .get(this._productsJsonUrl)
            .map((response: Response) => <IProduct[]>response.json())
            .catch(function (err: Response) {
                return Observable.throw(err.json().error || 'Server error');
            });
    }
}