import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Account, AccountResponse } from '../models/account';
import { ApiResponse } from '../models/api-response';


@Injectable({
  providedIn: 'root',
})
export default class AccountsService {
  constructor(private httpClient: HttpClient) { }

  getAllAccounts(): Observable<AccountResponse> {
    return this.httpClient.get<AccountResponse>(`${environment.apiUrlBase}Accounts/GetAllAccounts`);
  }

  getAllAccountsPaginated(pageIndex: number, pageSize: number): Observable<AccountResponse> {
    return this.httpClient.get<AccountResponse>(`${environment.apiUrlBase}Accounts/GetAllAccountsPaginated?pageIndex=${pageIndex}&pageSize=${pageSize}`);
  }

  openAccount(account: Account): Observable<ApiResponse> {
    const headers = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }
    console.log(account);
    return this.httpClient.post<ApiResponse>(`${environment.apiUrlBase}Accounts/OpenAccount`, JSON.stringify(account), headers);
  }
}