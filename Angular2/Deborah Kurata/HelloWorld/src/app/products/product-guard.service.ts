import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable()
export class ProductDetailGuardService implements CanActivate {
    constructor(private _router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let id = +route.url[1].path;
        if (isNaN(id) || id < 1) {
            alert('Invalid product id. Id must be a number greater than 0.');
            this._router.navigateByUrl('/products');
            return false;
        }

        return true;
    }
}