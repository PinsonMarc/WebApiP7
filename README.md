# WebAPI Project 7 
Seventh Openclassrooms project

A basic Rest API with tests, endpoints logging and authorization/authentication 

Build using:
- ASP.NET core 3.1 MVC
- SQL Server 
- EF Core, automapper, FluentValidation
- Asp.net Identity & JWT
- xUnit & Moq
- Swagger

# set up :
- Require .net core 3.1 and SQL Server
- Download the project in your machine
- Update the "DefaultConnection" in appsettings.json
- Run the solution (DB created and seeded on first app start)
- documentation is located on the "/swagger" endpoint

to login, get the token from the /login endpoint using admin credentials : 
 - userName => administrator
 - password => pass@word1
