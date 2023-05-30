# GlidedRose - Refactoring Steps
------------------
1. Project Set Up
 - Split Project into two; One console application and another for NUnit unit test application.
 - Update target framework from .NET Framework 4.0 to .NET 7
 - Update all dependent libraries

2. Define unit tests cases
 - Created unit tests for all given business scenarios.
 - Refactor to avoid repeated item creation in the same class.
 
3. Refactor Business Logic. 
 - Move model classes & business logic to separate folders
 - Re-write to simplify quality calculation logic in UpdateQuality method (Group related logic, simplify calculations)
 - Create constants file to move constants strings & constant numbers to avoid repeated usage in code

4. Added logic to support conjured items.
 - Modify existing business logic to add conjured items.
 - Create unit tests for conjured items.
