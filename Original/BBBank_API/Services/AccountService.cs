using Entities;
using Entities.Responses;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountsService
    {
        private readonly BBBankContext _bbBankContext;
        public AccountService(BBBankContext BBBankContext)
        {
            _bbBankContext = BBBankContext;
        }
        public async Task OpenAccount(Account account)
        {
            // Setting up ID of new incoming Account to be created.
            account.Id = Guid.NewGuid().ToString();
            // If the user with the same User ID is already in teh system we simply set the userId forign Key of Account with it else 
            // first we create that user and then use it's ID.
            var user = _bbBankContext.Users.FirstOrDefault(x => x.Id == account.User.Id);
            if (user == null)
            {
                _bbBankContext.Users.Add(account.User);
                account.UserId = account.User.Id;
            }
            else
            {
                account.UserId = user.Id;
            }
            // Once User ID forigen key and Account ID Primary Key is set we add the new accoun in Accounts.
             this._bbBankContext.Accounts.Add(account);
        }
    }
}