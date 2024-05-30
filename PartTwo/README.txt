PROG6221 - POE
Part 1 - Developing a Recipe Console Application
README file

Visual Studio and C# were used to develop this standalone console application.

Requirements
The following is required to use this application:
Microsoft Visual Studio 2019 or later
.NET Core 3.1 or later

How to Compile and Run
Download the source code from Github or create a clone of the repository.
Open the file with the source code in visual studio.
Run the application.
Follow the instructions presented on the command line to add a recipe, display the recipe, scale the quantities, clear the recipe, or exit the application.

Functionality
The user can enter the recipe name, the number of ingredients, the ingredient names, quanties of ingredients, unit of measurement, the number of steps, and the description for each step about a single recipe.
The computer presents the entire recipe neatly to the user, which includes the recipe name, ingredients, and steps.
The user is able to scale the recipe by a factor of 0.5, 2, or 3, and the quantities and potentially units for each ingredient are changed when the recipe is displayed.
The user is able to reset the quantities to their original values.
The user is able to clear all the data from a recipe so they can enter a new one.
The application does not store user data for future use, the data is stored in memory while the application is running.

Non-functional requirements
This application uses globally recognized coding standards and includes descriptive comments for variable names, methods, and programming logic.
This application consists of multiple classes for functionality.
Lists are used to store ingredients and steps.

Plugins
Plugins can be installed for this application for extra functionality. Here is the installation process:
1. Download the project.
2. Open the project in Visual Studio
3. Go to tools -> NuGet Package Manager -> Package Manager Console
4. Now use the command "add-package [plugin name]"

FAQ
Q: What do I use to run this program?
A: Microsoft Visual Studio with .NET Core and .NET Framework

Q: How do I add a recipe?
A: When presented the menu upon opening the application, type "1" as you option to add a new recipe

Q: How do I scale a recipe?
A: Type "4" as your option to open the menu for scaling a recipe, then enter the name of the recipe you want to scale and choose the scale factor you desir.

What I Changed from Part One
I have introduced welcome text that displays in the console upon starting the application as well as instructions on how to use the application. I have ensured that all the recipe values can be reset when scaling. For part 2, I have now actually assigned the scaled variables to the original variables to reset them, I have also fixed the bugs so the scaleRec() method works properly. I have also attempted to structure my code more efficiently and neatly. I implemented exception handling more into the project, so more exceptions are caught. I have also added code attribution in the README file and added the Git readme file to the repository.

Credits
The author of this application is Caleb Andersen, email st10251423@vcconnect.edu.za if you have any questions or concerns.
**CSharp_OOP_Fundamentals** by oguzhanKomcu. Available at: https://github.com/oguzhanKomcu/CSharp_OOP_Fundamentals/tree/master/Delegate_And_Exception (Accessed on: 2024-05-29)
**UnitTesting-MSTest-Examples** by atmanrathod. Available at: https://github.com/CMARIXTechnolabs/UnitTesting-MSTest-Examples (Accessed on: 2024-05-30)

Github
https://github.com/VCWVL/prog6221---programming-2a---part-2-CalebAndersen