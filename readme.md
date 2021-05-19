# A<span>SP.NET MVC Online Shop template

This repository contains a source code of A<span>SP.NET MVC Online shop template.

## Overall information

* The Online shop template was implemented using the A<span>SP.NET MVC framework.
* Entity Framework is used to ensure communication with MS SQL Server.
    * The Code First approach was used during the implementation process.
    * The migration feature was used several times during the development process.
* A<span>SP.NET Identity mechanism is used to ensure correct login, registration and verification of users.
* The system sends e-mails that confirms user registration and product purchase.
* Dynamic site map creation is implemented.
* The system uses cache to store some data to save time of response.
* The system uses the session mechanism when products are added or removed from th cart by users.
* It is possible to create a user with administrator privileges in the system.

## Functionality for users
* Registration and login process for users.
* The newest and discounted products are displayed on the home page.
* Products can be searched by category.
* Products can be added or removed from the cart.
* The user's personal data such as the delivery address or account password can be changed multiple times.
* The user can always check placed orders.
* Information about each existing order in the system (e.g. delivery address, content or status) is displayed and can be modified by users with administrator privileges.
* Products can be added, modified or removed from the system by users with administrator privileges.

## Features that will be added in the future:

* Improving the user interface - for example the use of the Bootstrap framework