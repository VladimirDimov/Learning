import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { LOGIN_ROUTE } from '../routes';

@Injectable()
export class NoopInterceptor implements HttpInterceptor {
    constructor(private router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var observable = next.handle(req);

        observable.subscribe(res => res, err => {
            if (err.status === 401) {
                this.router.navigateByUrl(LOGIN_ROUTE);
            }
        })

        return observable;
    }
}