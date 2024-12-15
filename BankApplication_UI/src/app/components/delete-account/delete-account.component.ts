import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/Accounts';

@Component({
  selector: 'app-delete-account',
  standalone: true,
  imports: [],
  templateUrl: './delete-account.component.html',
  styleUrl: './delete-account.component.css',
})
export class DeleteAccountComponent implements OnInit {
  constructor(private accountservice: AccountService) {}
  accountData: Account | null = null;
  accountNumber: number = 0;
  ngOnInit(): void {
    this.accountData = this.accountservice.getAccountData();
    if (
      this.accountData.accountNumber != undefined ||
      this.accountData.accountNumber != null
    ) {
      this.accountNumber = this.accountData.accountNumber;
    }

    console.log(this.accountData);
  }

  DeleteAccount() {
    this.accountservice.deleteAccount(this.accountNumber).subscribe((data) => {
      console.log(data);
    });
  }
}
