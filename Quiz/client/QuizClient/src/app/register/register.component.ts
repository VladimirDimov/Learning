import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  constructor( @Inject(FormBuilder) fb: FormBuilder, private userService: UserService) {

  }

  registerForm: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(5)]),
    repeatPassword: new FormControl('', [Validators.required, Validators.minLength(5)]),
  });

  ngOnInit() {
  }

  onRegister() {
    let model = this.registerForm.value;
  }
}
