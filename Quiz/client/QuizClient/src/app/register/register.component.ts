import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  constructor( @Inject(FormBuilder) fb: FormBuilder) {

  }

  registerForm: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.minLength(2)])
  });

  ngOnInit() {

  }

  onRegister() {
    console.log(this.registerForm);
    console.log(this.registerForm.controls.firstName.errors);
    console.log(this.registerForm.controls.firstName.pristine);
  }
}
