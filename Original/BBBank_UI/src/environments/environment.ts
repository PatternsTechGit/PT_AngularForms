// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrlBase: 'http://localhost:5070/api/',
  clientId: '66f42264-8560-4d8b-9670-c28bb9e1a0c4', // Application (client) ID from the app registration
  authority: 'https://login.microsoftonline.com/0c087d99-9bb7-41d4-bd58-80846660b536', // The Azure cloud instance and the app's sign-in audience (tenant ID, common, organizations, or consumers)
  redirectUri: 'http://localhost:4200', // This is your redirect URI
  postLogoutRedirectUri: 'http://localhost:4200/login',
  defaultScope: 'api://bbbankapi/default',
  azureAdUsersListUrl: 'https://prod-12.centralus.logic.azure.com:443/workflows/42946e9e79384d13b2b10bf4145e0f97/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=mAaSkHC0UbhcLKGp3IDSv5Qae5B2eYbv3mQiKoylTJg',
  client_secret: 'mrQ8Q~tonyXJvkaS5qapx9ug3P9TeC25g9uiKb.H',
  tenantid: '0c087d99-9bb7-41d4-bd58-80846660b536', 
  ApiclientId: '08cec2b2-20da-4194-a100-c80202232fd9'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
