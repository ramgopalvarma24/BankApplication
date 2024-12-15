import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/Accounts';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-account',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-account.component.html',
  styleUrl: './edit-account.component.css',
})
export class EditAccountComponent implements OnInit {
  balance: number | null = null;
  accountName: string | null = null;
  accountNumber: number | undefined;
  accountData: Account | null = null;
  constructor(
    private accountservice: AccountService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    
    // const navigation = this.router.getCurrentNavigation();
    // const state = navigation?.extras.state;
    // console.log(state);
    this.accountData = this.accountservice.getAccountData();
    console.log(this.accountData);
    this.accountNumber =this.accountData.accountNumber;
    this.accountName = this.accountData.accountName;
    this.balance = this.accountData.balance;

    //this.loadNotifications();
  }

  onSubmit() {
    console.log(this.balance);
    console.log(this.accountName);
    const acc: Account = {
      accountName: this.accountName,
      balance: this.balance,
    };
    this.accountservice
      .updateAccount(this.accountNumber, acc)
      .subscribe((data) => {
        console.log(data);
      });
  }
}
