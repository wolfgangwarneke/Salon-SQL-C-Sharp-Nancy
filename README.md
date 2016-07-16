# _Salon Administrator_

#### _A business tool for beauty salons, July 15th, 2016_

#### By _**Wolfgang Warneke**_

## Description

_Sometimes it's hard to keep track of your stylists at your beauty salon. But what if it wasn't so difficult? What if you could see who all works at
your salon?  Who the customers are?  Or which stylist the customer prefers to see? Whether owner, manager, secretary, or overstretched stylist handling multiple duties, this is for you. Add stylists. Update their name when they decide they would prefer to have their first name be Moonglow instead of Karen. Remove them after they decide to sail around the world the next seven years instead of working at your salon. Be jealous. But most of all, be organized and on top of your business. Less papercuts. More haircuts._

## Specifications

* _Adds new salon employees to the roster_
* _Displays all salon employees_
* _Edits salon employee information if needed_
* _Removes salon employee from database if they move on_
* _Adds new customers to the clients list_
* _Displays all customers_
* _Updates customer information if necessary_
* _Allow administrative user to remove customer if requested_
* _Pairs new customer with a stylist_
* _Updates customer/stylist pair if customer request to change_
* _Displays all customers for a selected stylist_

## Setup/Installation Requirements

* _This is a great place_
* _to list setup instructions_
* _in a simple_
* _easy-to-understand_
* _format_

_To launch this app you will need to use Nancy and SQL as well as C#. You can find information about Nancy here:_
*	_[NancyFX](https://github.com/NancyFx/Nancy)_

_You're going to need a SQL database, which will store your clients and stylists._
#### Database and Local Host Setup
* _Access your SQL server on the command line:_
  `sqlcmd -S "(localdb)\mssqllocaldb"`
* _Create a new database and switch context to it_
~~~~
CREATE DATABASE hair_salon;
GO
USE hair_salon;
GO
~~~~
* _Create a new table for stylists_
~~~~
CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(100));
GO
~~~~
* _Create a new table for stylists_
~~~~
CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(100), stylist_id INT);
GO
~~~~
* _Repeate previous steps for DATABASE hair_salon_test instead of DATABASE hair_salon._
* _Run 'DNU restore' on the command line._
* _Run 'DNX kestrel' to start local Nancy host._
* _Open [http://localhost:5004/](http://localhost:5004/) in your web browser_

## Known Bugs

_No known bugs at this time._

## Support and contact details

_DM me on Instagram: **@wolfgangwarneke**_

## Technologies Used

* _Nancy_
* _Razor_
* _C#_

### License

Copyright (c) 2016 **_Wolfgang Warneke_**
