import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UserService } from '../services/user.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  constructor(
    @Inject(FormBuilder) fb: FormBuilder,
    private userService: UserService, private http: HttpClient,
    private router: Router) {
  }

  registerForm: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.minLength(2)]),
    lastName: new FormControl('', [Validators.minLength(2)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(5)]),
    repeatPassword: new FormControl('', [Validators.required, Validators.minLength(5)]),
  });

  ngOnInit() {
  }

  onRegister() {
    if (!this.registerForm.valid) {
      return;
    }

    let model = {
      Email: this.registerForm.value.email,
      Password: this.registerForm.value.password,
      ConfirmPassword: this.registerForm.value.repeatPassword
    };

    debugger;
    this.userService.register(model).subscribe(
      res => {
        debugger;
        console.log('success');
        this.router.navigateByUrl('/user/login');
      },
      err => {
        debugger;
        console.log(err);
      }
    )
  }
}
