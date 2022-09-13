# NTChallenge

Task: See NTAG_Coding Challenge_dotnet_2022.pdf

Note: As I have only very vague knowledge about Front-End-Topics, I chose to focus on a backend oriented solution.
This results in a few possible changes in design, mainly that the Front-End relies on a Web API to get it's data,
weather it's the Open Weather Map data or a "self hosted DB".

## 1. Concept Creation

In this step I analyzed the general purpose of the tasks ahead. I created a sketch design (see architecture_concept.jpg) for the backend.
I also started this very small documentation of my working steps to for other to understand my original reasoning.

I am using git, with working branches that get merged into a master branch. I would usually have a second branch, staging, for a test enviroment.
I felt this, together with a working pipeline, would be overkill for this task. (Just as a sidenode, I prefer a semilinear history via git rebase, not really neccissary in a one-man-army approach ^^)

## 2. Creating Basic Project

My next step is to initialize a basic project. I chose the ASP .NET Core basic template. After creation I first deleted the standart WeatherForecast Controller (though I had the possibility of reusing them.)
Next I created a good structure like I am used to: a build folder for general, not code related stuff. A src directory to hold all the code. And last but not least a tests directory for the unit tests I want to add later on.

I configured the launch settings a little bit to remove all the annoying IIS overhead.

And lastly, I added a json converter in the launch setting. This is a precaution, as I will be communication via json.

## 3. Controller with Mock Response

In this step I want to create a basic controller.
I created a WeatherController, using the AspNetCore.MVC stuff. It has a simple get endpoint. I created a simple model for the returned object. I chose a record for this to get the advantage of immutability, as these are only data objects that will be returned to the outside.
Currently this dto has only one attribute, but more will follow later.

Now, when launched, the controller is automatically registered and the endpoint can be tested in the swagger gui. It will always return the fake response I created.

## 4. Service Layer

Next I have to create the service layer. This will be a new project (a class library). It will hold our general service logic. For communication to the api layer (and later db layer) I use domain objects.
I don't want the db later to reference my service layer, so I also create the class library domain, with it's purpose being the project containing my domain models.
(To apply my current naming policy i called the service layer project "Application". I will also use the name "application layer" in the following descriptions.)

To hide specific implementation, my application layer will only have interfaces as public. A small extension for the IServiceCollection will be public, so I can register the specific implementation for dependency injection within the program (here the api layer) that uses my library.

The first service will return a simple mock answer, like before. But now I will call the service (regestered by dependency injection) from my controller.

In this case I decided to implement the mapping of domain model to dto within the api layer. For now it's just a simple object, so we are fine without a mapping library for now.
An alternitive way could have been moving dtos and mapping into the service layer. But in this case I decided to not do that, as the mapping won't be a huge impact in this challenge. A reason to have the dtos in the service layer might be the need of a Client in form of a nuget in case another api or similar application needed to use a set interface for sending requests to my service. I currently don't see a use case for this in the given challenge.

With the current state I was confident in starting to add xml comments as part of the documentation (and to make the swagger more accessable for other).