import { ApiResponse } from "./api-response";

export class AccountListsResponse {
  accounts: Array<Account>;
  resultCount: number;
}

export class Account {
  accountTitle: string;
  user: User;
  currentBalance: number;
  accountStatus: number;
  accountNumber: string;
}
export class User {
  id: string;
  profilePicUrl: string;
  email: string;
  phoneNumber: string;
  firstName: string;
  lastName: string;
}
export interface AccountResponse extends ApiResponse {
  result: AccountListsResponse
}