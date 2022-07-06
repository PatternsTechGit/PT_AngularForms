import { Component, ElementRef, ViewChild } from '@angular/core';
import { Account, User } from './models/account';
import { AzureAdUser } from './models/azureAdUser';
import AccountsService from './services/accounts.service';
import AzureAdService from './services/azuread.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {

  @ViewChild('photo') photo: ElementRef;
  // Entire form and its controls are two way binded to this property.
  // This is the property when populated will be send back to server.
  public account: Account;
  // Array used to populate AD Users drop down.
  azureAdUsers: AzureAdUser[];
  // Selected user on drop down.
  selectedAdUser: AzureAdUser;
  constructor(private azureAdService: AzureAdService, private accountsService: AccountsService) {
    this.initializeEmptyForm();
  }
  onAdUserSelect() {
    // few of the  properties of account object will be populated from the properties of Azure AD User
    this.account.user.id = this.selectedAdUser.id
    this.account.user.firstName = this.selectedAdUser.givenName;
    this.account.user.lastName = this.selectedAdUser.surname;
    this.account.user.email = this.selectedAdUser.mail;
    /*     this.azureAdService
        .getAzureAdUsersPic(this.selectedAdUser.id)
        .subscribe({
          next: (data) => {
            console.log(data);
            this.photo['src'] = data['value'];
          },
          error: (error) => {
            console.log(error);
          },
        }); */
  }
  onSubmit() {
    console.log(this.account);
    this.accountsService
    // sending the two way binded and populated account object to the server to get persisted.
      .openAccount(this.account)
      .subscribe({
        next: (data) => {
          // clearing up the form again after form data is sent to server.
          this.initializeEmptyForm();
        },
        error: (error) => {
          console.log(error);
        },
      });
  }
  initializeEmptyForm() {
    // fetching list of Azure AD Users from azureAdService
    this.azureAdService
      .getAzureAdUsersList()
      .subscribe({
        next: (data) => {
          //console.log(data['value']);
          this.azureAdUsers = data['value'];
        },
        error: (error) => {
          console.log(error);
        },
      });
      // Setting up empty or default controls.
    //this.selectedAdUser = null;
    this.account = new Account();
    this.account.accountStatus = 1;
    this.account.user = new User();
    this.account.user.profilePicUrl = '../../assets/images/No-Image.png';
  }
}
