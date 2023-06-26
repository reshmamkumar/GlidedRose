# How to run the project?
-------------------------
1. Clone/download the project from Github repository.
2. Set GlidedRose.Console as start up project and start running the applciation.
3. New items can be added in Assets/items.json for the app to read.
4. Open test explorer in Visual studio to run unit tests

# GlidedRose - Refactoring Steps
------------------
1. Project Set Up
 - Split Project into three ; One console application and another for NUnit test application and third - a class library to define business logic. Seperating the business logic creates room for more loosely coupled code and enhance testability
 - Update target framework from .NET Framework 4.0 to .NET 7
 - Update all dependent libraries

2. Define unit tests cases
 - Created unit tests for covering all update quality scenarios of all products.
 - Refactor test cases.
 
3. Refactor Business Logic. 
 - Move model classes & business logic to separate class library
 - Re-write to simplify quality calculation logic in UpdateQuality method (Group related logic, simplify calculations)
 - Create constants file to move constants strings & constant numbers to avoid repeated usage in code

4. Added logic to support conjured items.
 - Modify existing business logic to add conjured items.
 - Create unit tests to cover conjured items.
   
5. Apply SOLID principles & Strategy pattern
 - Create separate interface for each item, applied strategy behavioural pattern to dynamically choose which items' **UpdateQuality** policy may be selected runtime.
 - Introduced dependency injection using Microsft.Extensions.Dependency injection for the console application to access business logic, following dependency 
   inversion principle.
   
   

