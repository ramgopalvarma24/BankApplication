import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/Accounts';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-accounts',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './all-accounts.component.html',
  styleUrl: './all-accounts.component.css',
})
export class AllAccountsComponent {
  accounts: Account[] = [];
  constructor(private accountService: AccountService, private router: Router) {}
  ngOnInit(): void {
    this.loadAccounts();
  }

  loadAccounts(): void {
    this.accountService.getAccounts().subscribe((data: Account[]) => {
      this.accounts = data;
      console.log(this.accounts);
    });
  }
  onDelete(account: Account) {
    this.accountService.setAccountData(account);
    this.router.navigate(['/delete']);
  }
  onEdit(account: Account) {
    // this.router.navigate(['/edit'], {
    //   state: {
    //     AccountNumber: account.accountNumber,
    //     AccountName: account.accountName,
    //     Balance: account.balance,
    //   },
    // });

    this.accountService.setAccountData(account);
    this.router.navigate(['/edit']);
    //throw new Error('Method not implemented.');
  }
  onAdd() {
    throw new Error('Method not implemented.');
  }
}
