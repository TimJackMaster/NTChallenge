# NTChallenge

Task: See NTAG_Coding Challenge_dotnet_2022.pdf

Note: As I have only very vague knowledge about Front-End-Topics, I chose to focus on a backend oriented solution.
This results in a few possible changes in design, mainly that the Front-End relies on a Web API to get it's data,
weather it's the Open Weather Map data or a "self hosted DB".

## 1. Concept Creation

In this step I analyzed the general purpose of the tasks ahead. I created a sketch design (see architecture_concept.jpg) for the backend.
I also started this very small documentation of my working steps to for other to understand my original reasoning.

I am using git, with working branches that get merged into a master branch. I would usually have a second branch, staging, for a test enviroment.
I felt that this, together with a working pipeline, would be overkill for this task. (Just as a sidenode, I prefer a semilinear history via git rebase, not really neccissary in a one-man-army approach ^^)

## 2. Creating Basic Project

My next step was to initialize a basic project. I chose the ASP .NET Core basic template. After creation I deleted the standart WeatherForecast Controller (though I had the possibility of reusing them.)
Next I created a good structure like I am used to: a build folder for general, not code related stuff. A src directory to hold all the code. And last but not least a tests directory for the unit tests I want to add later on.

I configured the launch settings a little bit to remove all the annoying IIS overhead.

And lastly, I added a json converter in the launch setting. This is a precaution, as I will be communication via json.

## 3. Controller with Mock Response

In this step I created a basic controller.
I created the WeatherController, using the AspNetCore.MVC stuff. A simple get endpoint returns a very basic model (my dto). I chose a record for this to get the advantage of immutability, as these are only data objects that will be returned to the outside.
Currently this dto has only one attribute, but more will follow later.

Now, when launched, the controller is automatically registered and the endpoint can be tested in the swagger gui. It will always return the fake response I created.

## 4. Service Layer

Next I created the service layer. This is a new project (a class library). It helds our general service logic. For communication to the api layer (and later db layer) I use domain objects.
I don't want the db later to reference my service layer, so I also created the class library called domain, with it's purpose being the project containing my domain models.
(To apply my current naming policy i called the service layer project "Application". I will also use the name "application layer" in the following descriptions.)

To hide specific implementation, my application layer will only have interfaces as public. A small extension for the IServiceCollection will also be public, so I can register the specific implementation for dependency injection within the program (here the api layer) that uses my library.

The first service returns a simple mock answer, like before. But now I will call the service (regestered by dependency injection) from my controller.

In this case I decided to implement the mapping of domain model to dto within the api layer. For now it's just a simple object, so we are fine without a mapping library for now.
An alternitive way could have been moving dtos and mapping into the service layer. But in this case I decided to not do that, as the mapping won't be a huge impact in this challenge. A reason to have the dtos in the service layer might be the need of a Client in form of a nuget in case another api or similar application needed to use a set interface for sending requests to my service. I currently don't see a use case for this in the given challenge.

With the current state I was confident in starting to add xml comments as part of the documentation (and to make the swagger more accessable for other).

## 5. Open Weather Map

Up until now the application was only capable of providing mock information. So the next step was to send requests to Open Weather Map.
For this the application layer got the OpenWeatherMapRequest, a class dedicated to call the OpenWeatherMap api and deserialize it's response into response objects.
This step has some tricky things in it. For example, it is the first module that will get Unit tests. For this I had to capsulate the RestClient into an interface, making it possible to later inject it via some form of mocking.
The API also needs a token, an api key, for a user. In an actual project it would get a key for production enviroment, which would likely be some paid subscription. In my case I simply created a free account and got my own key.
I don't want to share that key, and in an actualy project it could be fatal to commit an actual api key. For that reason I used user secrets to store my personal key.
I also capsulated the key and some other information into small structs and classes to achieve a more defined use of my methods and reduce thing I would've to test later.

Talking about tests: I created the Unit test project for the Application Layer! I am using xUnit as a testing framework, and Moq for mocking purposes.
Currently the OpenWeatherMapRequest doesn't do much, so I implemented only a first test, but more will come later.

The OpenWeatherMapRequest is called by the OwmWeatherInformationService, a specific implementation of the IWeatherInformationService interface. After regestering it in my ServiceExtension class it is now the used service and loads the temperature from the Open Weather Map API.
I also had to add parameters to my GET method in my controller. I am loading these from my query.

## 6. Full Response

So far the response had only consisted of a single property. In this step I added missing properties. This brought some unexspected difficulties.
My original plan was to use Automapper for the mapping from rest client response to domain object to dto. I had planned to create a Mapper instance, registered in the DI container and injected for the IMapper interface.
To not have the nuget installed in two projects I first had moved my dtos into the application layer (something I previously figured wouldn't be needed, but now it made more sense).
Then, after implementing the mapping rules, I realized after launching my unit test, that I had overlooked something: As I am using records for consistency in my object's states, I inherently prevented Automapper from initilizing my instances during the mapping.
Because the properties are immutable, Mapper throws an exception. This ultimately made my write my own little mapping extensions, with the knowledge of the objects not being big.

After some little adjustments and the addition of a unit test that would test the correct mapping in the OpenWeatherInformationRequestTests I had completely implemented the request sending logic for requesting data from Open Weather Map.

## Conclusion
As I don't have time to finish my remaining plans, I want to at least lay out the rest of my plan.
My next steps would be to add some error handling and response wrapping. The json response should consist of a result (holding the dto), a success field (boolean) and a field containing the http status code.
Next, as there was a database mentioned in the task sheet, I would implement a database layer using Entity Framework, and running it locally with a docker container containing the database. 

Overall, it was a fun little task, though I had to be a bit creative and taking some liberties as most of the task was oriented towards frontend implementation, which I don't have any expierince with. But I hope this project still displays my general process and philosophy when developing sonfware implementation.
