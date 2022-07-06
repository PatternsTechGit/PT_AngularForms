import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AzureAdUser } from '../models/azureAdUser';


@Injectable({
  providedIn: 'root',
})
export default class AzureAdService {
  constructor(private httpClient: HttpClient) { }

  // Azure logic app is already set to receive an empty POST request that does the magic of fetching the access token and returning list of AD users 
  getAzureAdUsersList(): Observable<AzureAdUser[]> {
    return this.httpClient.post<AzureAdUser[]>(environment.azureAdUsersListUrl, {
      "client_secret" : environment.client_secret,
      "client_id" : environment.ApiclientId,
      "tenantid" : environment.tenantid
    });
  }

  getAzureAdUsersPic(userId: string): Observable<Blob> {
    return this.httpClient.post<Blob>('https://prod-22.centralus.logic.azure.com:443/workflows/15e69b91abdf45a283c5ffdfc9cb7289/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=H5DkFcaBzModcqXFXk6A4FUbfbMHGlUdBpeJ1CUKnfs', { userId: userId });
  }
}