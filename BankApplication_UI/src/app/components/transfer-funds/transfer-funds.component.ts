import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/Accounts';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-transfer-funds',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './transfer-funds.component.html',
  styleUrl: './transfer-funds.component.css',
})
export class TransferFundsComponent {
  constructor(private accountservice: AccountService) {}
  transferData = {
    fromAccount: null,
    toAccount: null,
    amount: null,
  };

  accountslist: Account[] = [];
  ngOnInit(): void {
    this.loadAccounts();
  }

  loadAccounts(): void {
    this.accountservice.getAccounts().subscribe((data: Account[]) => {
      this.accountslist = data;
      console.log(this.accountslist);
    });
  }
  transferFunds() {
    if (this.transferData.fromAccount === this.transferData.toAccount) {
      alert('From Account and To Account cannot be the same.');
      return;
    }
    console.log(this.transferData);
    this.accountservice.transferFunds(this.transferData).subscribe((data:any)=>{
      console.log(data);
    })
  }
}
