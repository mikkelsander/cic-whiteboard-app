import { Injectable } from '@angular/core';

import { OAuthService, NullValidationHandler, JwksValidationHandler } from 'angular-oauth2-oidc';


import { Observable, from, pipe, of } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { authConfig, DiscoveryDocumentConfig } from '../config/auth-config';

@Injectable()
export class AuthService {

  constructor(private oauthService: OAuthService) {
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
  }

  tryAuthenticate(): Observable<boolean> {
    console.log('authenticating')
    return from(this.oauthService.loadDiscoveryDocument(DiscoveryDocumentConfig.url))
      .pipe(
        switchMap(() => this.oauthService.tryLoginImplicitFlow()),
        switchMap(() => of(this.oauthService.hasValidAccessToken())),
      );
  }

  redirectToSignInPage(): void {
    this.oauthService.initLoginFlow();
  }

  signOutUser(): void {
    this.oauthService.logOut();
  }

  getClaims(): any {
    return this.oauthService.getIdentityClaims();
  }

  isAuthenticated(): boolean {
    return this.oauthService.hasValidAccessToken();
  }
}
