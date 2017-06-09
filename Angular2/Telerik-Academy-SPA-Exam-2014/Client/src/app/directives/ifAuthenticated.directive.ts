import { Directive, ElementRef, Renderer, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { CookieService } from "angular2-cookie/services";
import { GlobalConstants } from "../common/global-constants";
import { LoginComponent } from "../login/login.component";
import { AuthService } from "../services/auth-service";

@Directive({
    selector: '[ifAuthenticated]',
})

export class IfAuthenticatedDirective implements OnChanges {
    @Input('ifAuthenticated') display: boolean = true;

    constructor(
        public el: ElementRef,
        public renderer: Renderer,
        private _cookieService: CookieService,
        private _authService: AuthService) { }

    ngOnInit() {
        this.refresh();
        if (this._authService.onLoginEvent != null) {
            this._authService.onLoginEvent.subscribe(data => {
                this.refresh();
            });
        }

        if (this._authService.onLogoutEvent != null) {
            this._authService.onLogoutEvent.subscribe(data => {
                this.refresh();
            });
        }
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.refresh();
    }

    private refresh() {
        if (this.isAuthenticated() != this.display) {
            this.renderer.setElementStyle(this.el.nativeElement, 'display', 'none');
        } else {
            this.renderer.setElementStyle(this.el.nativeElement, 'display', '');
        }
    }

    private isAuthenticated(): boolean {
        var authCookie = this._cookieService.get(GlobalConstants.BearerTokenCookie);

        return authCookie != null;
    }
}