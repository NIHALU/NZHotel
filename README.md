# NZHotel
**Bu proje, Full Stack .Net Software kursunun bitirme projesidir.**  
NZ Hotel is an application that a hotel can use in a resort area.  
The project has a complex structure with management, reception and web modules.  
--The reception module will include parts such as taking reservations, registration of hotel guests, check-in and check-out procedures, status and tracking of rooms.

--Also, it can display the reservations made by the customers through the web module. It also includes the daily rates. WebApi is used.

--The management module can follow all the work done by the reception module. In addition, the records and accounting sections related to the employees are included in this module. Registration and authorization of employees as users are also performed in this module.

The web module is the part that promotes the hotel to the customer and enables them to make reservations over the internet.

The project is  N-tier architecture.
We added 6 projects, one of which is Asp.Net Core Web App (by adding MVC), to the Blank Solution we opened in VS. These are;
- Entities
- Data Access Layer
- Business Logic Layer
- DTOs 
- Common (Response ve Enums)
- UI

**Nuget Package Manager was used to add the necessary packages and libraries to our project.**
  DAL =>  (Microsoft.AspNetCore.Identity.EntityFrameworkCore 5.0.17 & Microsoft.EntityFrameworkCore.SqlServer 5.0.17 && Microsoft.EntityFrameworkCore.Tools 5.0.17)
  (Microsoft.AspNetCore.Identity 2.2.0 &)
  
 ORM technology **Entity Framework Core(with Code First approach)** is used and necessary Configurations&Mapping operations are done with FluentApi. 
 MSSQL server database is used.
The **Asp.NET Core Identity** library was used for the membership system.

Generic Repository Design Pattern is used for CRUD operations for each model
we have established a general structure for our common operations and ensure that each model performs that operation through this general structure.

**what is a generic repository Design Pattern and what are its advantages?**
--The repository pattern is used to create an abstraction layer between the data access layer and the business layer of an application
--This pattern helps to reduce code duplication and follows the DRY principle.
--It also helps to create loose coupling between multiple components, when we want to change something inside the data access layer that time does not need to change another layer where we consume that functionality.
--Separation of concern makes things easier to maintain the code.
--Implementing repository patterns helps us write unit test cases efficiently and easily.

**In addition to the Generic Repository, we also used the Unit Of Work model.**
We created another folder called UnitOfWork and define the IUnitOfWork interface in it.
We defined the GetRepository generic method, which will bring us the type of repository we want, and the SaveChanges methods, which will allow us to batch save operations.

The dependency injection of DbContex is handled by the constructor method of the Unit Of Work class and All Repositories use the same DbContext type.

**we added a folder is called DependencyResolver into BLL, and then in this folder we opened a static class called dependency Extension**
we installed the **Microsoft.Extensions.DependencyInjection** package
In this way we expanded the IServiceCollection interface
We  pulled our connection string from appsetting.jsons via IConfiguration
Finally, we called our extension via services(IServiceCollection) in startup.

UI => (Microsof.EntityFrameworkCore.Design 5.0.17)
We created our migration to be the default project data access and startup project UI via the package manager console.
(add-migration InitialCreate -outputDir Migrations)
and then saved our migration to the database(update-database)



DTOs are used for data transfer between layers and ViewModels are used in the UI when they are necessary.
We used the **AutoMapper** library which dynamically converts these different types of objects to each other.
(AutoMapper 12.0.1)

In order to ensure the security of the applications we develop and the accuracy of the data to be recorded, we need to verify the data sent by the users.

Thanks to the flexible structure of **FluentValidation**; It allows us to write complex rules easier to understand and customize more easily when we add.

Using Client-Side and Server-Side together is a safer approach to guarantee data accuracy.

Using “Data Annotation”, we can also validate by adding attributes in our entity model classes.

This is a preferred and easy-to-use structure, but we also make validation adjustments to a class that is functionally designed as an entity, which is against the **"Single Responsibility Principle" of SOLID Principles**.

so we added the **Fluent Validation** library to our project.
BLL => FluentValidation (11.4.0)
(FluentValidation.DependencyInjectionExtensions 11.4.0)

**Thanks to FluentValidation library, We can perform both Client-Side and Server-Side verification.**
  
  
 




