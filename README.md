[![.NET Backend](https://github.com/faridprogrammer/module-plus-template/actions/workflows/dotnet.yml/badge.svg)](https://github.com/faridprogrammer/module-plus-template/actions/workflows/dotnet.yml)

# Important

This repository is based on the original **ASP.NET Core MVC / Angular startup** template [here](https://github.com/aspnetboilerplate/module-zero-core-template).

# Introduction

This is a template to create **ASP.NET Core MVC / Angular** based startup projects for [ASP.NET Boilerplate](https://aspnetboilerplate.com/Pages/Documents). 

User Interface is based on [AdminLTE theme](https://github.com/ColorlibHQ/AdminLTE). 

# Features

### Ready to use entity models

1. Basic accounting transactions
2. Invoices and invoice items
3. Payments
4. Countries
5. State provinces
6. Cities
7. Addresses
8. Faqs
9. Tickets

### Notes on entities

In order to make the entities simpler, I have had some assumptions regarding entities. 

1. There is no Foreign Key implemented in entities. Though there are referencing Id columns in related entities as needed.
2. Entity Id in all entities are `Guid`


### Ready to use application services 

There is already implemented simple `AsyncCrudApplicationService` for each of the entities above. As following:

1. `TransactionsAppService`
2. `InvoicesAppService`
3. `InvoiceItemsAppService`
4. `Countries`
5. `AddressesAppService`
6. `CitiesAppService`
7. `CountriesAppService`
8. `StateProvincesAppService`
9. `PaymentsAppService`
10. `FaqsAppService`
11. `TicketsAppService`

You can learn about application services [here](https://aspnetboilerplate.com/Pages/Documents/Application-Services)


### Store logs in database

In the log4net configuration, I have added and `AdoNetAppender` which adds logs to a table named `MpLogs`. There is also an application service implemented to query the `MpLogs` table.

### Application services for already existing stuff

1. Application service for query the logs (`LogsAppService`)
2. Application service for query audit logs (`AuditLogsAppService`)

### Basic user interface for all existing entity models

1. Application logs
2. Cities
3. StateProvinces
4. Countries
5. Faqs
6. Tickets
7. ... (Under construction)

### Code analysis results

[![CodeScene general](https://codescene.io/images/analyzed-by-codescene-badge.svg)](https://codescene.io/projects/19415)

# License

[MIT](LICENSE).
