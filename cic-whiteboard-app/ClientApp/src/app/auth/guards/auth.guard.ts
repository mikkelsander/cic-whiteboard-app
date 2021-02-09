import { Injectable } from "@angular/core";
import { CanActivate, CanActivateChild } from '@angular/router';
import { Observable, of } from 'rxjs';
import { tap, switchMap } from 'rxjs/operators';
import { AuthService } from "../services/auth.service";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private _authSevice: AuthService) { }

    canActivate(): Observable<boolean> {
        return of(this._authSevice.isAuthenticated())
            .pipe(
                switchMap(authenticated => {
                    return authenticated ? of(authenticated) : this._authSevice.tryAuthenticate();
                }),
                tap(success => {
                    if (!success) this._authSevice.redirectToSignInPage(); 
                    
                    
                })
            )
    }
}