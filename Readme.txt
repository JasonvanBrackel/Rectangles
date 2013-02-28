Jason van Brackel Rectangle Solution
------------------------------------

Introduction
------------
This document serves as a short introduction to the vanBrackel.Rectangles application.

Note
----
This project was intentionally over engineered in order to show off use of different patterns and skills throughout the application.


What is this application?
-------------------------
This application is an application addressing the problem domain outlined in the docs\Rectangles_Sample.pdf document.

Prerequisites
-------------
.NET Framework 4.0
Visual Studio 2012 
An internet connection (to update NuGet packages on build)

Build Instuctions
-----------------
Open the src\vanBrackel.Rectangles.sln file
Build the application.
Click Start to run the application in the debugger.

Installation Instructions
-------------------------
Run the Rectangles.msi file to install the application to run.

Known Issues
------------
--There are some translation issues between WPF's math for drawing rectangles.  I don't quite have a handle on the bug yet.  I can't find the pattern in order to wrap it in a repeatable unit test.  Depending on the direction when drawing the rectangle, they will not always match up as expected. The X and Y coordinates created by the canvas are displayed.

-I could not get Nant to build using the project files.  This is my first attempt with VS2012/NAnt/NuGet together.  I don't have the time to replace <solution> tasks with <csc> tasks so I'm dropping it at this point.

Troubleshooting
---------------
NAnt Error: Windows 7 Security Related
Before unziping the nant-0.92-bin.zip file (if it has not yet been done)

1. Right click on the file.
2. Select properties.
3. Go to the General tag.
4. Click on Unblock and Close.
5. Unzip the nant-0.92-bin.zip file.
