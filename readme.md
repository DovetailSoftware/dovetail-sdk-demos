Dovetail SDK Demos
==================

These Demos were provided with Dovetail SDK, and served as a good starting point for many applications. Our resources have changed a lot over the years, so we separated the demos out into this repo. They are still a good resource, but have been replaced by the examples found in [Dovetail Bootstrap](https://github.com/DovetailSoftware/dovetail-bootstrap).

## .Net Console Demo

Demonstrates how a developer can use the SDK to add/import records to their database from another source (such as an XML file in this case).

Edit the App.config file to update the connection string with your development database information.

`<add key="fchoice.connectionstring" value="Data Source=.; Initial Catalog=clarify12; User Id=sa; Password=sa;" />`

To execute the Console demo, compile the FChoice.Foundation.Clarify.Demo.ConsoleAppCS project, and open a console window, and change to the "src\FChoice.Foundation.Clarify.Demo.ConsoleAppCS\bin\Debug" folder. 

Running `ConsoleAppCSDemo.exe` will import the addresses found in the "address.xml" file.


## .Net WinForms Demo

A simple Windows Forms application which allows a user to add new addresses to their Clarify database. It shows how a developer can populate a drop-down list from items cached by CacheManager and ClarifyApplication as well as create a new record in the database using the ClarifyGeneric class.

Edit the App.config file to update the connection string with your development database information.

`<add key="fchoice.connectionstring" value="Data Source=.; Initial Catalog=clarify12; User Id=sa; Password=sa;" />`

To execute the WinForms demo, compile the FChoice.Foundation.Clarify.Demo.WinAppCS project, then launch the demo from within Visual Studio using ctrl-F5. Once the address form pops up, it can be used to insert addresses into the database.


## ASP.Net Web Demo

A simple ASP.NET web application which demonstrates the use of some key concepts such as how to use the ClarifyApplication and ClarifySession classes in an ASP.NET environment. It also features a few ASP.NET server controls that can be used for data-binding to user-defined pop-up lists (HGBST's).

In order for the web demo to work, a virtual directory needs to be set up under IIS. The physical path for the virtual directory should be the "src\FChoice.Foundation.Clarify.Demo.WebAppCS" folder.

Edit the Web.config file to update the connection string with your development database information.

`<add key="fchoice.connectionstring" value="Data Source=.; Initial Catalog=clarify12; User Id=sa; Password=sa;" />`
