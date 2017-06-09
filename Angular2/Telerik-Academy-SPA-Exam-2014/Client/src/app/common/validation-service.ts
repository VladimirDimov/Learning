import { Injectable } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

@Injectable()
export class ValidationService {

    formGroup: FormGroup;

    constructor() { }

    getFormErrors(controlName: string) {
        if (!this.formGroup) {
            throw 'Before using the validation service set its formGroup';
        }

        let control = this.formGroup.controls[controlName];
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
        let control = this.formGroup.controls[controlName];
        return !control.pristine && control.errors != null;
    }
}