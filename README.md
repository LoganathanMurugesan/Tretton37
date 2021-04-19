# Engima1337

Enigma1337 is a tool built specifically for Tretton37 to extract static content from a website including CSS, images, js files etc and saves them to a downloads folder in local machine.

***


### Thought Process

There is a possibility to write this whole application in a single method, but thanks to object-oriented programming which helped to make this more modularized, readable, testable and maintainable. Delegating the tasks to a separate the module increased the development speed and to spot the errors. Programming to an interface helped in decoupling the dependencies which eventually allowed to test it easily. Each module is highly cohesive and loosely coupled.

***


### Stories/Features 

#### All the stories are pre-planned and executed in a sequence. It is a chain of reaction where one leads to another. Every time a branch is cut down from the main branch and on completing the feature merged back to the main branch. Below are the features developed.

*Local-directory-Creation



* Html-Link-Extractor



* Link-Formatter



* Resource-Downloader



* Create/Integrate-DirectoryFinder



* Progress-Bar



* Traverse-WebPages



* Modularize-and-Refactor



* Global-Exception-Handler



* Abstracting-download-process



* Adding-Xunit-test-cases



***

### Instructions to install, build and run the application



* Install visual studio 2019 along with .net core 3.1 .

* Down the source code from the github link - https://github.com/LoganathanMurugesan/Tretton37 .

* Navigate to the downloaded solution folder.

* Open the application in visual studio by double clicking the solution file -  Enigma1337.sln.

* Once the application is loaded in visual studio choose the green start button to build and run the application, or simply press F5.

* Once the application starts, a console window will open and shows the progress bar of the download.

* Application will download all files from the website - https://tretton37.com/ and saves them in downloads folder in your local machine.



































