# JapTask1
Sample task done as a part of Continuous education programme at Mistral technologies. Goal of this task was to showcase **.NET** and **React** skills after following two courses for a week.

The project is a recipe app that allows users to create new recipes or list existing ones, and also it will calculate the price of entered recipe, based on the price of every single ingredient.

The project was developed using `.NET version 6` with `SQL Server Express` for backend and `React.JS` as a frontend framework (using `create-react-app`) on Ubuntu machine.

## Prerequisites 
In order to run the project make sure you have the following installed on your machine:
> .NET 6.0 framework [Can be downloaded here](https://dotnet.microsoft.com/en-us/download)
> SQL Server Express [Link to download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
> .NET Entity framework
> Node environment

### Setup project
1. Make sure you have cloned the repository on your local machine and move to project root `/jap-task`.
2. Switch to api directory using `cd api`.
3. Run the migrations in order to create the database and seed it with initial data `dotnet ef database update`. This will create new database called `japdb`.
4. Start the backend using `dotnet watch run` command. The api should be available at `https://localhost:7024`.
5. Open second terminal and run `npm install` then `npm run`, this should make the client app available at `localhost:3000`.

Once you have both frontend and backend running you should be able to sign in to the app using following credentials:
`username: admin`
`password: admin123`