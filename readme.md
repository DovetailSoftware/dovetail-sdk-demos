Dovetail SDK Demos
==================

These Demos were provided with Dovetail SDK, and served as a good starting point for many applications. Our resources have changed a lot over the years, so we separated the demos out into this repo. They are still a good resource, but have been replaced by the examples found in [Dovetail Bootstrap](https://github.com/DovetailSoftware/dovetail-bootstrap).

## .Net Console Demo

Demonstrates how a developer can use the SDK to add/import records to their database from another source (such as an XML file in this case).

Edit the App.config file to fill in the connection information to your development database.

## .Net WinForms Demo

A simple Windows Forms application which allows a user to add new addresses to their Clarify database. It shows how a developer can populate a drop-down list from items cached by CacheManager and ClarifyApplication as well as create a new record in the database using the ClarifyGeneric class.

Edit the App.config file to fill in the connection information to your development database.

## ASP.Net Web Demo

A simple ASP.NET web application which demonstrates the use of some key concepts such as how to use the ClarifyApplication and ClarifySession classes in an ASP.NET environment. It also features a few ASP.NET server controls that can be used for data-binding to user-defined pop-up lists (HGBST's).

In order for the web demo to work it requires a virtual directory setup under IIS.

Edit the Web.config file to fill in the connection information to your development database.
