# Angular Forms


## What is angular form

Applications use forms to enable users to log in, to update a profile, to enter sensitive information, and to perform many other data-entry tasks.

Angular provides two different approaches to handle **user input** through **forms**: 
* Template-driven Forms
* Reactive Forms

We will use **template-driven** form.

Here is how both forms works in a nutshell:

![approach](./readme_assets/choosinganapproach.png)


## **About this exercise**
Previously we worked on two codebase, **Backend Codebase** and **Frontend Codebase**. On backend side we performed data seeding for our API so that we can show that data in our frontend application from the database:

**Backend Codebase**
#### Previously we did

* EF Code first approach to generate Database of a fictitious bank application called **BBBank**.
* Applied data seeding to the database.

For more details see [data seeding](https://github.com/PatternsTechGit/PT_AzureSql_EFDataSeeding) lab.

**Frontend Codebase**
#### Previously we did

* Created client side models to receive data
* Created transaction service to call the API
* Fixed the CORS error on the server side
* Populated html table, using data returned by API

For more details see [Angular calling API](https://github.com/PatternsTechGit/PT_AngularCallingAPI) lab.

![angularCallingAPI](./readme_assets/angularcallingapi.jpg)


## **In this exercise**

In this exercise again we will be working on two codebase i.e. **Backend Codebase** and **Frontend Codebase**.

**Backend Codebase**

#### On backend side we would:
* Do necessary model changes and execute migration commands
* Create an **account service** and a contract for this service in the **Service** project 
* Register the **service in asp core pipeline** as scoped 
* Create an **account controller** with method `OpenAccount`

**Frontend Codebase**
#### On frontend side we would:
* Create **template driven form** 
* Perform **input fields validation**  
* Call the **account service** to **save data in database** 

**Backend Implementation**

Follow the below steps to implement backend code changes:

## Step 1: User and Account model changes

We will make some user model properties nullable so that if these are not provided from frontend then we should not be getting errors thrown by database so user model would be looks like this. Consider the question mark (?) in front of properties that needs to be nullable . 

```cs
    public class User : BaseEntity // Inheriting from Base Entity class
    {
        // First name
        public string? FirstName { get; set; }

        // Last name
        public string? LastName { get; set; }

        // Email of the user
        public string Email { get; set; }

        // Profile picture or avatar
        public string? ProfilePicUrl { get; set; }

        // Account attached to the user 
        public virtual Account Account { get; set; }
    }

```

And account model would looks like below, see the `AccountStatus` decorated with `[JsonConverter(typeof(JsonStringEnumConverter))]` so that it can map frontend values to account status enum.

```cs
    public class Account : BaseEntity // Inheriting from Base Entity class
    {
        // String that uniquely identifies the account
        public string AccountNumber { get; set; }

        //Title of teh account
        public string AccountTitle { get; set; }

        //Available Balance of the account
        public decimal CurrentBalance { get; set; }

        // This decoration is required to conver integer coming in from UI to respective Enum
        [JsonConverter(typeof(JsonStringEnumConverter))]
        //Account's status
        public AccountStatus AccountStatus { get; set; }

        //Setting forignkey to resolve circular dependency
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        // One User might have 1 or more Accounts (1:Many relationship) 
        public virtual User User { get; set; }

        // One Account might have 0 or more Transactions (1:Many relationship)
        public virtual ICollection<Transaction> Transactions { get; set; }
    }

    // Two posible statuses of an account
    public enum AccountStatus
    {
        Active = 1,     // When an account can perform transactions
        InActive = 0    // When an account cannot perform transaction
    }
```

## Step 2 Data migration
In step 1 we did some changes in `User` model, now we need to execute data migration commands so that changes can be reflected in database as well.

Execute following commands one by one:

>Add-Migration FormsLab

>Update-Database

## Step 3: Creating Interface for Account Service

In **Services** project create an interface (contract) in **Contracts** folder to implement the separation of concerns.
It will make our code testable and injectable as a dependency.

```csharp
public interface IAccountsService
{
    Task OpenAccount(Account account);
}
```

## Step 4: Creating Account Service Implementation

In **Services** project we will be implementing account service. Create new file **AccountService.cs**

In this file we will be implementing **IAccountsService** interface, below code would be used\
In `OpenAccount` method first we are checking if user does not exists then create new user otherwise update existing user.

```csharp
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
        var user = await _bbBankContext.Users.FirstOrDefaultAsync(x=>x.Id == account.User.Id);
        if (user == null)
        {
            await _bbBankContext.Users.AddAsync(account.User);
            account.UserId = account.User.Id;
        }
        else
        {
            account.UserId = user.Id;
        }
        // Once User ID forigen key and Account ID Primary Key is set we add the new accoun in Accounts.
        await this._bbBankContext.Accounts.AddAsync(account);
        // Once everything in place we make the Database call.
        await this._bbBankContext.SaveChangesAsync();
    }
}
```

## Step 5: Register Account and Database Context Service

In `Program.cs` file we will add **BBBankContext** and **IAccountsService** to services container.

```csharp
builder.Services.AddScoped<IAccountsService, AccountService>();
builder.Services.AddScoped<DbContext, BBBankContext>();
```

## Step 6: Creating Open Account API

Create a new API controller named `AccountsController` and inject the `IAccountsService` using the constructor.

```csharp
private readonly IAccountsService _accountsService;
public AccountsController(IAccountsService accountsService)
{
    _accountsService = accountsService;
}
```

Now we will create an API method **OpenAccount** in `AccountsController` to call the service so that new account can be created.

```csharp
[HttpPost]
[Route("OpenAccount")]
public async Task<ActionResult> OpenAccount(Account account)
{
    try
    {
        await _accountsService.OpenAccount(account);
        return new OkObjectResult("New Account Created.");
    }
    catch (Exception ex)
    {
        return new BadRequestObjectResult(ex);
    }
}
```

## Step 7: Disable ASP.NET Core model validation 

We need to disable ASP.NET Core model validation so that we does not get model validation errors as non-nullable `Account` model properties would be expecting values. So add following code in `program.cs`

```cs
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
```
Now backend is ready and would be proceeding to implement frontend.