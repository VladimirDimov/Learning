import { Injectable, EventEmitter } from "@angular/core";
import { CookieService } from "angular2-cookie/core";

const ACCESSS_TOKEN_COOKIE: string = 'access_token';

@Injectable()
export class SharedService {
    constructor(private cookieService: CookieService) { }

    public refreshLogin = new EventEmitter();

    public isAuthenticatedProp: boolean = true;

    public refreshIsAuthenticated() {
        this.isAuthenticatedProp = this.cookieService.get(ACCESSS_TOKEN_COOKIE) != null;
    }
}