# .NET Core | Postgres | Docker 

An eazy-peazy template for building a .NET Core app with Postgres.

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



## How is this so easy?

Docker-Compose takes care of installing the Dotnet runtime, a PostgreSQL server, and NodeJS all in separate, disposable **containers**. 
You don't need to worry about installing this software by hand, nor should you worry about mucking up existing versions of these programs on your OS.
