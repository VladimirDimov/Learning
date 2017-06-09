// https://scotch.io/tutorials/angular-2-form-validation

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AuthService } from '../services/auth-service';
import { IRegisterModel } from '../models/register.model';

import { ToastrService } from 'toastr-ng2';

@Component({
    selector: 'cp-register',
    templateUrl: './register.component.html',
    providers: [FormBuilder]
})

export class RegisterComponent implements OnInit {

    private registerForm: FormGroup;
    private isAttemptedSubmit: boolean = false;

    constructor(private formBuilder: FormBuilder, private _authService: AuthService, private toastr: ToastrService) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            'email': ['user2@site.com', Validators.compose([Validators.required])],
            'password': ['123456', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(10)])],
            'confirmPassword': ['123456', Validators.required],
            'car': ['Citroen Xsara Picasso', Validators.compose([])],
            'isDriver': [false]
        }, { validator: this.validateConfirmPasswords });
    }

    onRegister(value: IRegisterModel): void {
        var result = this._authService.register(value)
            .subscribe(data => {
                this.toastr.success('User created!');
            }, err => {                
                this.toastr.error(err);
            });
    }

    validateConfirmPasswords(group: FormGroup) {
        var password = group.controls['password'] === null ? null : group.controls['password'].value;
        var confirmPassword = group.controls['confirmPassword'] === null ? null : group.controls['confirmPassword'].value;

        if (password != confirmPassword) {
            group.controls['confirmPassword'].setErrors({ invalidConfirmPassword: true })
        }
    }

    getFormErrors(controlName: string) {
        let control = this.registerForm.controls[controlName];
        if (control === null) {
            throw 'Invalid control name: ' + controlName;
        }

        if (!control.hasError) {
            return null;
        }

        let errors = [];
        for (let err in control.errors) {
            switch (err) {
                case 'required':
                    errors.push('The ' + controlName + ' is required');
                    break;

                case 'minlength':
                    errors.push('The ' + controlName + ' must be at least 5 characters long');

                default:
                    break;
            }
        }

        return errors.join('\r\n');
    }

    isShowErrors(controlName: string): boolean {
        let control = this.registerForm.controls[controlName];
        return !control.pristine && control.errors != null;
    }
}