# .NET Core | Postgres | Docker 

An easy project built using  .NET6 with Postgres and Docker engine. 

## To Run

The only requirement is [Docker Compose](https://docs.docker.com/compose/).

Clone the repo:

```bash
git clone https://github.com/josimagas/HigherOrLowerGame
cd HigherOrLowerGame
docker-compose build
docker-compose up
```

Navigate to `localhost:5000/swagger/index.html` to explore the API using **SwaggerUI**.

## Test Coverage
For simplicity the test coverage files are included in the **HigherOrLowerGame/HigherOrLowerGame.Tests/TestResults/7bd2608f-b83d-4900-afe1-eedb6c3a0d28/coveragereport/** 
You just need to click on `index.html` file


## How is this so easy?

Docker-Compose takes care of installing the Dotnet runtime, a PostgreSQL server, and NodeJS all in separate, disposable **containers**. 
You don't need to worry about installing this software by hand, nor should you worry about mucking up existing versions of these programs on your OS.
