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
