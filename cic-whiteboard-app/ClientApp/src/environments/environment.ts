// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,

  API_BASE_URL: window.location.origin + '/api',
  POST_HUB_URL: window.location.origin + '/postHub',
  
  CLIENT_ID: '527cd959-80e0-443a-ba27-52c63dadc0c8',
  TENANT_ID: '81605c16-630d-41cf-a98d-d97fa258953a',
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
