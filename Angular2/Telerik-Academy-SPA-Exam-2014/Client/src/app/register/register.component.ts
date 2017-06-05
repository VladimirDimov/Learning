// https://scotch.io/tutorials/angular-2-form-validation

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AuthService } from '../services/auth-service';
import { IRegisterModel } from '../models/register.model';

@Component({
    selector: 'cp-register',
    templateUrl: './register.component.html',
    providers: [FormBuilder]
})
export class RegisterComponent implements OnInit {

    private registerForm: FormGroup;
    private isAttemptedSubmit: boolean = false;

    constructor(private formBuilder: FormBuilder, private _authService: AuthService) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            'email': [null, Validators.compose([Validators.required])],
            'password': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(10)])],
            'confirmPassword': [null, Validators.required],
            'car': [null, Validators.compose([])],
            'isDriver': [false]
        }, { validator: this.validateConfirmPasswords });
    }

    onRegister(value: IRegisterModel): void {
        var result = this._authService.register(value)
            .subscribe(data => {
                console.log(data);
            }, err => {
                console.log(err);
            });
    }

    validateConfirmPasswords(group: FormGroup) {
        var password = group.controls['password'] === null ? null : group.controls['password'].value;
        var confirmPassword = group.controls['confirmPassword'] === null ? null : group.controls['confirmPassword'].value;
        return password === confirmPassword ? null : { invalidConfirmPassword: true };
    }
}