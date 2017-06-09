import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ValidationService } from '../common/validation-service';
import { HttpRequester } from '../common/http-requester';
import { ILoginResponse } from '../models/login-response.model';
import { GlobalConstants } from "../common/global-constants";
import { ToastrService } from "toastr-ng2/toastr";
import { AuthService } from "../services/auth-service";
import { Router } from "@angular/router";

@Component({
    moduleId: module.id,
    selector: 'cp-login',
    templateUrl: 'login.component.html',
})

export class LoginComponent {
    private loginForm: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private validation: ValidationService,
        private _http: HttpRequester,
        private toastr: ToastrService,
        private _authService: AuthService,
        private _router: Router)
    { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            'username': ['user2@site.com', Validators.compose([Validators.required])],
            'password': ['123456', Validators.compose([Validators.required])]
        });

        this.validation.formGroup = this.loginForm;
    }

    onLogin(model: any) {
        this._authService.login(model)
            .subscribe(data => {
                this._router.navigate(['']);
                this.toastr.success("User logged in!");
            }, err => {
                this.toastr.error(err);
            });
    }
}