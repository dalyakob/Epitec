# Epitec
All personal learning experiences/exercises 

i.	Worked on implementing a different ORM, RepoDB to replace Entity Frameworks in my solution. 
ii.	No controlled layer like DbContext, which speeds-up the usability and allows you to connect to database adding a project reference to the Infrastructure. 
iii.	Created a getbyId endpoint that utilized repoDb and created Integration tests for it
iv.	I was stuck on integration tests for a bit but I realized the issue was with overriding of the configuration of the main database with the testing database. I used the main one as a temporary fix because I was stuck on that issue for longer than expected.
v.	Completed Module 6 which integrates the onion architecture into the solution. And I realized that the modules were leading to a more Onion Architecture type build and only certain project will have access to some information.
vi.	Module 7 implemented Domain-Driven-Design which basically organized all instantiation and methods that affect the state of Entities in one domain model
vii.	I also added Unit tests specifically for Domain model testing
viii.	 Module 8 implements the Repository Pattern which in short is a way to implement data access by encapsulating sets of objects in repository. And it provides a more object oriented view of persistence layers. It increases testability and makes swapping out data stores really easy without changing the api
ix.	Module 9: BLAZOR APP, integrated a Blazor app to display contacts and implement a contact service to get premade contacts
x.	Module 10: integrated an http service to get the contacts from the api
