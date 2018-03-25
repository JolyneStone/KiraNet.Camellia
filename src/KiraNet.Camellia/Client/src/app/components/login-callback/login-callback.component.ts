import { AuthService } from './../../services/auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { User } from 'oidc-client';

@Component({
  selector: 'app-login-callback',
  templateUrl: './login-callback.component.html',
  styleUrls: ['./login-callback.component.css']
})
export class LoginCallbackComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.authService.loginCallBack()
      .subscribe((user: User) => {
        this.toastr.info("Login success, redirecting...", "Login")
        if (user) {
          window.location.href = '/';
        }
      })
  }

}
