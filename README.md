<!-- ABOUT THE PROJECT -->
# GraphQL API using Hot Chocolate

GraphQL is a query language for APIs and a runtime for fulfilling those queries with your existing data. GraphQL provides a complete and understandable description of the data in your API, gives clients the power to ask for exactly what they need and nothing more, makes it easier to evolve APIs over time, and enables powerful developer tools.


<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

Things you need to use the software and how to install them.
* [Visual Studio / Visual Studio Code](https://visualstudio.microsoft.com/)
* [.NET 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7/)
* [Docker](https://www.docker.com/)

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/gitViwe/GraphQL.git
   ```
2. Run via VisualStudio / VS Code
   ```
   cd graphql
   dotnet run
   ```
3. Run via Docker
   ```
   cd graphql
   docker compose up --build -d
   ```

### Get started 
If you have setup everything correctly, you should be able to open the GraphQL IDE Banana Cake Pop at [http://localhost:5192/graphql](http://localhost:5192/graphql)

### Executing a query
Let's start with performing queries on the database. You can find some graph queries in the folder `/graphql/query`

### Executing a mutation
Then we can modify some data. You can find some graph mutations in the folder `/graphql/mutation`
Remember to add the JWT token to the HTTP header 'Authorization' for the GraphQL requests. `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkMGM5YTU0OS01MWNlLTRhN2QtODhjNi0yOGUxZDgxNDVlZTAiLCJ1bmlxdWVfbmFtZSI6IlZpd2U0NTYiLCJlbWFpbCI6ImV4YW1wbGUtMkBlbWFpbC5jb20iLCJqdGkiOiI1NGZkOTg2MS05YWUwLTQ4ZWYtYmJhMi01MGRiMWJlNmRiYjEiLCJuYmYiOjE2Njk0NjIxNzcsImV4cCI6MTY2OTQ2Mjc3NywiaWF0IjoxNjY5NDYyMTc3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTYxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE2MSJ9.LZ9pObhNp7XSeU6LvQEMDioHvH7PFPipIrcSVaPrW1M`

### Executing a subscription
Now subscribe to events. You can find some graph subscriptions in the folder `/graphql/subscription`
Let's create another `deployOverwatchHero` and check the `superHeroDeployed` subscription for this event.
