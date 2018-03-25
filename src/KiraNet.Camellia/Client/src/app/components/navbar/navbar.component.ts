import { FlashMessagesService } from 'angular2-flash-messages';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';
import { User } from 'oidc-client';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  public isLoggedIn: boolean;
  public loggedInUser: User;

  constructor(
    private authService: AuthService,
    private router: Router,
    private flashMessage: FlashMessagesService
  ) { }

  ngOnInit() {
    this.authService.loginStatusChanged.subscribe((user: User) => {
      this.loggedInUser = user;
      this.isLoggedIn = !!user;
      if (user) {
        this.flashMessage.show('Login success', { cssClass: 'alert alert-success', timeout: 4000 });
      }
    });
    this.authService.checkUser();
  }

  login() {
    this.authService.login();
  }

  logout() {
    this.authService.logout();
  }

}
