// https://scotch.io/tutorials/angular-2-form-validation

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'cp-register',
    templateUrl: './register.component.html',
    providers: [FormBuilder]
})
export class RegisterComponent implements OnInit {

    private registerForm: FormGroup;

    constructor(private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            'email': [null, Validators.compose([Validators.required])],
            'password': [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(10)])]
        });
    }

    onRegister(value: any): void {
        console.log(value);
    }
}