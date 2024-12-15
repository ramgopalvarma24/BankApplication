import { Component, OnInit } from '@angular/core';
import { FormGroup, FormsModule } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/Accounts';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-account',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create-account.component.html',
  styleUrl: './create-account.component.css',
})
export class CreateAccountComponent {
  //form: FormGroup;
  balance: number | null = null;
  accountName: string | null = null;
  constructor(private accountservice: AccountService) {}

  onSubmit() {
    console.log(this.balance);
    console.log(this.accountName);
    const acc: Account = {
      accountName: this.accountName,
      balance: this.balance,
    };
    this.accountservice.createAccount(acc).subscribe((data) => {
      console.log(data);
    });
  }
}
