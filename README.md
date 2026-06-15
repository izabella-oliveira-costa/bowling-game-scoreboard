# Bowling Game Scoreboard

A REST API built with ASP.NET Core to calculate bowling game scores according to official bowling rules, including strikes, spares, and bonus rolls.

## Features

* Calculate bowling game scores
* Support for strikes and spares
* RESTful API endpoint
* Swagger/OpenAPI documentation
* Unit tests with xUnit
* Docker support
* Ready for deployment on Google Cloud Run

## Tech Stack

* ASP.NET Core (.NET 10)
* xUnit
* Docker
* Google Cloud Run
* Firebase Hosting (Frontend)

## Project Structure

```text
bowling-game-scoreboard
├── BowlingGameScoreboard
│   ├── Models
│   ├── Services
│   ├── Program.cs
│   └── BowlingGameScoreboard.csproj
│
├── BowlingGameScoreboard.Tests
│   ├── BowlingTests.cs
│   └── BowlingGameScoreboard.Tests.csproj
│
├── Dockerfile
└── bowling-game-scoreboard.sln
```

## Running Locally

```bash
dotnet restore
dotnet run --project BowlingGameScoreboard
```

The API will be available at:

```text
http://localhost:5000
```

Swagger documentation:

```text
http://localhost:5000/swagger
```

## Running Tests

```bash
dotnet test BowlingGameScoreboard.Tests
```

## API Endpoint

### Calculate Score

**POST**

```text
/api/bowling/score
```

### Request

```json
{
  "rolls": [
    1,4,
    4,5,
    6,4,
    5,5,
    10,
    0,1,
    7,3,
    6,4,
    10,
    2,8,6
  ]
}
```

### Response

```json
{
  "score": 133
}
```

## Test Coverage

Implemented unit tests for:

* Gutter Game
* All Ones
* Spare Bonus
* Strike Bonus
* Perfect Game (300)
* Example Game (133)

## Docker

Build image:

```bash
docker build -t bowling-game-scoreboard .
```

Run container:

```bash
docker run -p 8080:8080 bowling-game-scoreboard
```

## Deployment

The backend is designed to run on Google Cloud Run and can be consumed by a lightweight frontend hosted on Firebase Hosting.

## Author

Izabella Costa
