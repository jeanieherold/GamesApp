
# CSHARP ASP.NET Memory Game App 
* Code Louisville Project - Spring 2021 Razor/ Blazor Memory Game App

## Using ASP.NET Razor Pages with Blazor Components (Pages, Models, Controllers, Services, Data)

## No Javascript was used for this project except the blazorserver js file and bootstrap js included in Razor pages

## How to Run the App
1. Clone or Download the repo
2. Open GamesApp.sln in Visual Studio or preferred IDE for C#
3. Click Run
4. You will be taken to Home Page where you can enter in your user info or Go directly to the Memory Game from top nav or link above the form. 

## Features that I implememted from the C# Project Requirements Document
1. Card Services and Player Services use lists and populate it displaying User Info and Cards - reads and writes to these files as needed. 
2. CardServices and PlayerServices reads data from an external file, such as text, JSON, CSV, etc and use that data in your application
3. CardServices and Player Services use LINQ queries to retrieve information from a data structure (such as a list or array) or file
4. CardServices and PlayerServices implement reading and writing important events and writes them to a text file
5. User repeatedly performs actions - clicking on cards, can open instructions and close them, can start a new game or edit their information. 

## Created the Following:
* Home Page
    * Pages/Index.cshtml (& corresponding Index.cshtml.cs)
        * Created a form to capture or update user info and store in the players.json data file

* Memory Game Page
    * Pages/Games/Memory.cshtml (& correspoinding Memory.cshtml.cs)
        * Player UserName is pulled from data if user entered - else "Player One" shows
        * Player Score is updated as game progresses and matches are made
        * cards.json file is updated as game progresses and matches are made 
        * When match is made score is updated and card is disabled
        * Buttons for Directions, Edit Player Info and New Game
            * Directions - shows a modal with Game Directions
            * Edit Player - takes user to the edit player form - returning to game updates user info
            * New Game - Restarts the game with a shuffled deck. 
        * Linq 
            * I use Linq in conjunction with Services/Controllers to update selected cards / players
        * ALL card flipping, updating and logic for match/ score update handled in the CardList.razor component

* Models
    * Models/Card.cs - Card Class
    * Model/Player.cs - Player Class

* Game Blazor Component
    * Components/CardList.razor
        * Blazor Component for Game Play update. CardList.razor (I should have called this component GamePlay.razor - more accurate)
        * Handles Game Play and functionality on Memory Game page

* Services/Controllers 
    * Services/JsonFileCardService.cs
        * Controllers/CardsController.cs
    * Services/JsonFilePlayerService.cs
        * Controllers/PlayersController.cs
    * CardService and PlayerService to handle Serialize and Deserialize of cards.json and players.json
    * Controller for Cards and Players
    * Controller for both configured in Startup.cs file
    * API for players : /players
    * API for cards : /cards

* Assets in wwwroot
    * I created the css and image assets used. 
        * card images were purchased from BigStock.com 
        * I edited images using Adobe Illustrator and Adobe Photoshop as needed. 

* References 
    * I had no outside help in the building of this app except from the Class Mentors and Many tutorials. In addition Stack Overflow helped on how to handle updating element ClassList without js
    * Tutorials
        * https://teamtreehouse.com/tracks/-code-lou-c-2021
        * https://www.youtube.com/watch?v=68towqYcQlY&t=7s
        * youtube series asp.net core 101 by Microsoft
        * https://stackoverflow.com/questions/60295220/change-class-for-selected-div-only

* Final Notes : I am continuing to learn more about Blazor to improve this project with courses from iamtimcorey.com 

* Suggestions are welcomed! 