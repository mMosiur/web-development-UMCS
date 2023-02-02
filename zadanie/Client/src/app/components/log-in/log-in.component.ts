import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {

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

    console.log("Login page: " + this.userName);
    console.log("Login page: " + this.password);

    this.authService.login(this.userName, this.password)
      .subscribe(() => {
        console.log("Login Success");
        this.router.navigate(['/images']);
      });
  }
}
