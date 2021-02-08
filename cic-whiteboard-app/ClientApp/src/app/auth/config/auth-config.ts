import { AuthConfig } from "angular-oauth2-oidc";
import { environment } from "src/environments/environment";

  export const DiscoveryDocumentConfig = {
    url : 'https://login.microsoftonline.com/' + environment.TENANT_ID + '/v2.0/.well-known/openid-configuration'
  }
  
  export const authConfig: AuthConfig = {
    issuer: 'https://login.microsoftonline.com/' + environment.TENANT_ID,
    loginUrl: 'https://login.microsoftonline.com/' + environment.TENANT_ID + '/oauth2/v2.0/authorize',
    tokenEndpoint: 'https://login.microsoftonline.com/' + environment.TENANT_ID + '/oauth2/v2.0/token',
    redirectUri: window.location.origin + '/index.html',
    clientId: environment.CLIENT_ID,  
    responseType: 'token id_token',
    scope: 'https://cicwhiteboard.onmicrosoft.com/cic-whiteboard-api/user_impersonation', 
    silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
    sessionChecksEnabled: true,
    showDebugInformation: true,
    skipIssuerCheck: true,
    clearHashAfterLogin: true,
    oidc: true,
    strictDiscoveryDocumentValidation: false,
  };