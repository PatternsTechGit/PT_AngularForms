# Angular Forms


## What is angular form

Applications use forms to enable users to log in, to update a profile, to enter sensitive information, and to perform many other data-entry tasks.

Angular provides two different approaches to handle **user input** through **forms**: 
* Template-driven Forms
* Reactive Forms

**We will use template-driven form**.

[Choosing](https://angular.io/guide/forms-overview#choosing-an-approach) which approach to adopt can be decided as:

![approach](./readme_assets/choosinganapproach.png)


## **About this exercise**
Previously we worked on two codebase, **Backend Codebase** and **Frontend Codebase**. On backend side we performed data seeding for our API so that we can show that data in our frontend application from the database:

**Backend Codebase**
#### Previously

* we used EF Code first approach to generate Database of a fictitious bank application called **BBBank**.
* Applied data seeding to the database.

For more details see [data seeding](https://github.com/PatternsTechGit/PT_AzureSql_EFDataSeeding) lab.

**Frontend Codebase**
#### Previously

* Created client side models to receive data
* Created transaction service to call the API
* Fixed the CORS error on the server side
* Populated html table, using data returned by API

For more details see [Angular calling API](https://github.com/PatternsTechGit/PT_AngularCallingAPI) lab.

![angularCallingAPI](./readme_assets/angularcallingapi.jpg)


## **In this exercise**

In this exercise again we will be working on two codebase i.e. **Backend Codebase** and **Frontend Codebase**:

**Backend Codebase**

#### On backend side we would:
* Create an **account service** and a contract for this service in the **Service** project 
* Register the **service in asp core pipeline** as scoped 
* Create an **account controller** with method `OpenAccount`
* Create an **account** 

**Frontend Codebase**
#### On frontend side we would:
* Create **template driven form** 
* Perform **input fields validation**  
* Call the **account service** to **save data in database** 
