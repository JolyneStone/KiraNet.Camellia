import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { Injectable, EventEmitter } from '@angular/core';
import { Log, UserManager, User } from 'oidc-client';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

Log.logger = console;
Log.level = Log.DEBUG;

@Injectable()
export class AuthService {
  readonly _authType = 'Bearer';
  // userKey字符串是oidc-client在localStorage默认存放用户信息的key, 这个可以通过oidc-client的配置来更改.
  private userKey = `oidc.user:${environment.authConfig.authority}:${environment.authConfig.client_id}`;
  private manager: UserManager = new UserManager(environment.authConfig);

  public loginStatusChanged: EventEmitter<User> = new EventEmitter();

  constructor(
    private router: Router,
    private httpClient: HttpClient
  ) {
    // 当token过期或根本没有token的时候，调用login方法
    // this.manager.events.addAccessTokenExpired(() => this.login());
  }

  public get authType(): string {
    return this._authType;
  }

  public get token(): string | null {
    const temp = localStorage.getItem(this.userKey);
    if (temp) {
      const user: User = JSON.parse(temp);
      return user.access_token;
    }

    return null;
  }

  public get authorizationHeader(): string | null {
    if (this.token) {
      return `Bearer ${this.token}`;
    }

    return null;
  }

  public login() {
    // 跳转到Authorization Server的登录页面
    this.manager.signinRedirect();
  }

  public loginCallBack(): Observable<User> {
    return Observable.create(observer => {
      Observable.fromPromise(this.manager.signinRedirectCallback())
        .subscribe((user: User) => {
          this.loginStatusChanged.emit(user);
          this.manager.events.addAccessTokenExpired(() => this.login());
          observer.next(user);
          observer.complete();
        });
    });
  }

  public checkUser() {
    this.tryGetUser().subscribe((user: User) => {
      this.loginStatusChanged.emit(user);
    }, e => {
      this.loginStatusChanged.emit(null);
    });
  }


  public tryGetUser() {
    return Observable.fromPromise(this.manager.getUser());
  }

  public logout() {
    // 跳转到Authorization Server的退出页面
    this.manager.signoutRedirect();
    this.manager.events.removeAccessTokenExpired(() => { });
  }
}
