Feature: NorthwindTest
	As a User
	I want to open Northwind application
	So I can create product


Scenario: Create product
	Given I open "http://localhost:5000/Account/Login?ReturnUrl=%2F" url
	When I login with name "user" and password "user"
	And I click on All products link
	And I click on Create new button
	And I type in ProductName "testName"
	And I select in Category "Beverages"
	And I select in Supplier "Exotic Liquids"
	And I type in UnitPrice "1000"
	And I type in QuantityPerUnit "100"
	And I type in UnitsInStock "100"
	And I type in UnitsOnOrder "10"
	And I type in ReorderLevel "2"
	And I click on Send button
	Then there should be product with name "testName"