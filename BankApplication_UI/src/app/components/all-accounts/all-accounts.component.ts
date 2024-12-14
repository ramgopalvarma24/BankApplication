import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/Accounts';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-all-accounts',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './all-accounts.component.html',
  styleUrl: './all-accounts.component.css'
})
export class AllAccountsComponent {
  accounts: Account[] = [];
  constructor(private accountService: AccountService){}
  ngOnInit(): void { 
    this.loadAccounts(); 
  }

  loadAccounts(): void { 
    this.accountService.getAccounts().subscribe((data: Account[]) => {
       this.accounts = data; 
       console.log(this.accounts)
      }); 
    }
  onDelete(_t17: any) {
  throw new Error('Method not implemented.');
  }
  onEdit(_t17: any) {
  throw new Error('Method not implemented.');
  }
  onAdd() {
  throw new Error('Method not implemented.');
  }

}
