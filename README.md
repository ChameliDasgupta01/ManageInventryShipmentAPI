 Manage Inventory Shipment System

 Overview

	- Manage Inventory Shipment System API  - ManageInventryShipmentAPI
	  	This is developed Using the .NET Core API to perform the backend activity for the CRUD implementation of Inventory and Shipment Management 		System.
	- Manage Inventory Shipment System UI  - WFManageInventryShipment
		This is developed using Windows Forms and utilizes an API to perform CRUD (Create, Read, Update, Delete) operations. The application enables 		

Features
	• Add, Update, Delete, View product for the inventory (Product) items.
	• Dependency Injection (Constructor Injection).
	• Logging implementation to trace the logs through ILogger DI 
	• Unit test cases for code coverage (N-Unit Framework) 
		- Add the following NuGet packages to the project for Entity Framework and logging 
			1. Moq,
			2. NUnit,
			3. NUnit3TestAdapter 
			4. Microsoft.NET,Test,SDK
			5. Microsoft.Entity.FrameworkCore
			6. Microsoft.Extentions.Loggin
	• dbContext - Use Entity framework and create CustomdbContext class to communicate with database through DI.
			1. Microsoft.EntityFrameworkCore
			2. Microsoft.EntityFrameworkCore.Design
			3. Microsoft.EntityFrameworkCore.SqlServer
			4. Microsoft.EntityFrameworkCore.Tools
	• User-friendly interface with Windows Forms.

Technical Stack
	• Frontend - .NET 6.0 Windows Form, C#, WEB API (REST API) Integration.
	• Backend - .NET Core (.NET 6), C#, SQL Server, ContextDb, DI, Entity Framework

Setup Instructions
	- Prerequisites
		• Visual Studio 2022
		• Windows Forms: NET 6.0-windows
		• API: NET 6.0 for Rest API
		• SQL Server 2019 or any compatible database


Installation
	- Clone the repository: 
		git clone API -> https://github.com/ChameliDasgupta01/ManageInventryShipmentAPI/tree/main/ManageInventryShipmentAPI
		git clone UI->  https://github.com/ChameliDasgupta01/ManageInventryShipmentAPI/tree/main/WFManageInventryShipment
	- Open the Solution in Admin Mode: 
		o API -> Open ManageInventryShipmentAPI.sln in Visual Studio.
		o UI -> Open WFManageInventryShipment.sln in Visual Studio.
	- Configure the Database: 
		o Update the connection string in appsettings.json to point to your database connection string.
	- Build the solution and run the application from Visual Studio.
Usage
1. Add Product: 
	  o Use the form to input product details for new inventory items and add them to the database.
2. Product List 
	  o Display the product list on the dataGridview.
	  o Product details can be Add, edit and delete from this page.
	  o On any of dataGridView1_CellClick, the selected row will display on the details form.	
3. Edit and Delete Items: 
	  o Select an item from the list and edit its details from add/edit form. 
	  o Select the product from the list and then perform the delete operation.
4. Logging 
	  o All operations are logged in Logs folder in separate text file based on dates to handle exception & debugging purposes.
5. Field label Validation - on product detail form (Required Field/Int checking/Decimal checking)






