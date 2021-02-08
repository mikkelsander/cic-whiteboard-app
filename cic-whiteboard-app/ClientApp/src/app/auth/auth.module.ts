import { NgModule } from '@angular/core';
import { OAuthModule } from 'angular-oauth2-oidc';
import { environment } from 'src/environments/environment';
import { AuthGuard } from './guards/auth.guard';
import { AuthService } from './services/auth.service';



@NgModule({
  declarations: [],
  imports: [
    OAuthModule.forRoot({
      resourceServer: {
        allowedUrls: [ environment.API_BASE_URL ],
        sendAccessToken: true,
      }
    })
  ],
  providers: [ AuthService, AuthGuard ]
})
export class AuthModule { }
