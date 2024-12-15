import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-all-transactions',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './all-transactions.component.html',
  styleUrl: './all-transactions.component.css'
})
export class AllTransactionsComponent {
  transactions: any[] = []; // Array to hold the transaction history
  errorMessage: string | null = null; // To hold any error message

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.loadTransactionHistory();
  }

  // Method to load transaction history
  loadTransactionHistory(): void {
    this.accountService.getTransactionHistory().subscribe(
      (data) => {
        this.transactions = data;

      },
      (error) => {
        this.errorMessage = 'Error fetching transaction history.';
      }
    );
  }
}
