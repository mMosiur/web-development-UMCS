# Picture Portal

Author: Mateusz Moruś

## About

The project consists of database, backend and frontend.

For the database **MongoDb** was used as was recommended in the classes course.

For the backend project in spite of class recommendation .NET 7 was used, coded in C#.

For the frontend project in spite of class recommendation Angular 15 was used, coded in TypeScript.

## Prerequisites

- .NET 7
- Node 16
- Docker

## Running the project

Recommended way of running the project is using `docker compose`.

With the command:

```sh
docker compose up
```

In the root folder of the project docker should start up and the website should be available on **http** port **80**.

You can also run these manually, but you need to set up mongodb locally (eg. using docker also).

After mongo is running on localhost port **27017** you can start up server by:

```sh
cd Server
dotnet run
```

After the server is running you can install packages necessary for the frontend project:

```sh
cd Client
npm install
```

When these are installed, you can run the frontend project using

```sh
npm run start
```

A local server is going to be instantiated on port 4200. You can interact with the system through that.
