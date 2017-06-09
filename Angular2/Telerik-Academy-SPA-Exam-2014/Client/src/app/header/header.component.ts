import { Component } from '@angular/core';
import { AuthService } from "../services/auth-service";
import { ToastrService } from "toastr-ng2/toastr";
import { Router } from "@angular/router";

@Component({
    moduleId: module.id,
    selector: 'cp-header',
    templateUrl: 'header.component.html'
})

export class HeaderComponent {
    pageTitle: string = 'Header';

    constructor(
        private authService: AuthService,
        private toastr: ToastrService,
        private _router: Router)
    { }

    logout() {
        this.authService.logout()
            .subscribe(res => {
                this._router.navigate(['login']);
                this.toastr.success('User has logged off.');
            }, err => {
                this.toastr.error(err);
            });
    }
}