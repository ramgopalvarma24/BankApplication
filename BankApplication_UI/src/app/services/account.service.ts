import { Injectable } from '@angular/core';
import { Account } from '../models/Accounts';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private apiUrl = 'https://localhost:7078/api/Accounts';
  private tranApiUrl = 'https://localhost:7078/api/Transaction';
  private account: Account = { accountName: '', balance: 0 };
  setAccountData(data: any) {
    this.account = data;
  }
  getAccountData() {
    return this.account;
  }

  constructor(private http: HttpClient) {}
  getAccounts(): Observable<Account[]> {
    return this.http.get<Account[]>(this.apiUrl);
  }
  createAccount(account: Account): Observable<Account> {
    return this.http.post<Account>(this.apiUrl, account);
  }
  updateAccount(id: number | undefined, account: Account): Observable<Account> {
    account.accountNumber = 0;
    console.log(account);
    return this.http.put<Account>(`${this.apiUrl}/${id}`, account);
  }
  deleteAccount(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
  //transer funds
  transferFunds(data: any): Observable<any> {
    return this.http.post<any>(this.tranApiUrl, data);
  }
  getTransactionHistory(): Observable<any[]> {
    return this.http.get<any[]>(this.tranApiUrl);
  }
}
