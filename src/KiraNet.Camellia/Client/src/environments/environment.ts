import { WebStorageStateStore } from 'oidc-client';

// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

/*
authority就是authorization server的地址.
redirect_url是登陆成功后跳转回来的地址.
silent_redirect_uri是自动刷新token的回调地址.
automaticSilentRenew为true是启用自动安静刷新token.
userStore默认是放在sessionStorage里面的, 我需要使用localStorage
*/
export const environment = {
  production: false,
  authConfig: {
    authority: 'http://localhost:5000',
    client_id: 'client_id',
    redirect_uri: 'http://localhost:5200/login-callback',
    response_type: 'id_token token',
    scope: 'openid profile email client_name',
    post_logout_redirect_uri: 'http://localhost:5200',
    silent_redirect_uri: 'http://localhost:5200',
    accessTokenExpiringNotificationTime: 4,
    userStore: new WebStorageStateStore({ store: window.localStorage })
  },
  ServerApiBase: 'http://localhost:5100/api/'
};
