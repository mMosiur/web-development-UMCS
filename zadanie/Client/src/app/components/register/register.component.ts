import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  userName: string;
  password: string;
  formData: FormGroup;

  constructor(private authService: AuthService, private router: Router) {
    this.userName = "";
    this.password = "";
    this.formData = new FormGroup({
      userName: new FormControl("admin"),
      password: new FormControl("admin"),
    });
  }

  onClickSubmit(data: any) {
    this.userName = data.userName;
    this.password = data.password;

    console.log("register page: " + this.userName);
    console.log("register page: " + this.password);

    this.authService.register(this.userName, this.password)
      .subscribe(() => {
        console.log("register Success");
        this.router.navigate(['/images']);
      });
  }
}
