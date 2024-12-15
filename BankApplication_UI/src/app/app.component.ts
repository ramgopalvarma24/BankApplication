import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { AllAccountsComponent } from "./components/all-accounts/all-accounts.component";
import { FormsModule } from '@angular/forms';
import { LayoutsComponent } from "./commonLayout/layouts/layouts.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HomeComponent, AllAccountsComponent, FormsModule, LayoutsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BankApplication_UI';
}
