import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CreateAccountComponent } from './components/create-account/create-account.component';
import { DeleteAccountComponent } from './components/delete-account/delete-account.component';
import { EditAccountComponent } from './components/edit-account/edit-account.component';
import { AllAccountsComponent } from './components/all-accounts/all-accounts.component';
import { AllTransactionsComponent } from './components/all-transactions/all-transactions.component';
import { TransferFundsComponent } from './components/transfer-funds/transfer-funds.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'create', component: CreateAccountComponent },
  { path: 'delete', component: DeleteAccountComponent },
  { path: 'edit/:id', component: EditAccountComponent },
  { path: 'edit', component: EditAccountComponent },
  { path: 'allaccounts', component: AllAccountsComponent },
  { path: 'alltransactions', component: AllTransactionsComponent },
  { path: 'transferfunds', component: TransferFundsComponent },
];
