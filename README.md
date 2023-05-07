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
2. Run via Docker
   ```
   cd graphql
   docker compose up --build -d
   ```

Then navigate to [http://localhost:5161/swagger](http://localhost:5161/swagger), register or login to get a JWT token.

### Executing a query
Remember to add the JWT token to the HTTP header 'Authorization' for the GraphQL requests.
`Bearer <token>`

If you have setup everything correctly, you should be able to open [GraphQL IDE Banana Cake Pop](https://chillicream.com/docs/hotchocolate/v12/get-started-with-graphql-in-net-core/#executing-a-query) at [http://localhost:5192/graphql](http://localhost:5192/graphql)

Let's start with checking the entries on the database
```
query {
  heroes {
    id
    name
    alias
    createdBy
  }
}
```

Now subscribe to the hero created event
```
subscription {
  heroCreated {
    id
    name
    alias
  }
}
```

Let's create our own hero and check the `heroCreated` subscription for this event
```
mutation {
  addSuperHero(input: {name: "John Doe", alias: "JD"}) {
    id
    name
    alias
  }
}
```

Next, we fire up another subscription for updating a hero.
```
subscription {
  heroUpdated(heroId: 1) {
    id
    name
    alias
  }
}
```

Finally update a hero and check the `heroUpdated` subscription for this event. You can only edit those you created.
```
mutation {
  updateSuperHero(superHeroId: 1, input: {name: "GuyDude A", alias: "Bro A"}) {
    id
    name
    alias
  }
}
```
