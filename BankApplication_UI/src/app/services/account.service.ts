import { Injectable } from '@angular/core';
import { Account } from '../models/Accounts';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private apiUrl = 'https://localhost:7078/api/Accounts';

  constructor(private http:HttpClient) { }
  getAccounts(): Observable<Account[]> {
    return this.http.get<Account[]>(this.apiUrl); 
  }
  createAccount(account: Account): Observable<Account> {
    return this.http.post<Account>(this.apiUrl, account);
  }
  updateAccount(id: number, account: Account): Observable<Account> { 
    return this.http.put<Account>(`${this.apiUrl}/${id}`, account); 
  } 
  deleteAccount(id: number): Observable<void> { 
    return this.http.delete<void>(`${this.apiUrl}/${id}`); 
  }
}
