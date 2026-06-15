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
│   ├── Controllers
│   ├── Domain
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
http://localhost:5010
```

Swagger documentation:

```text
http://localhost:5010/swagger
```

## Running Tests

```bash
dotnet test BowlingGameScoreboard.Tests
```

## API Endpoint

### Calculate Score

**POST**

```text
/api/Bowling/score
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

200 - OK
```json
{
  "success": true,
  "message": "Score calculated successfully",
  "data": {
    "score": 133
  }
}
```
400 - Bad Request - Thrown when individual entries break value boundary conditions (e.g., negative pins or a single roll knocking down more than 10 pins).

```json
{
  "success": false,
  "message": "Roll must be between 0 and 10.",
  "data": null
}
```
422 - Unprocessable Entity - Thrown when the array sequence violates bowling game rules (e.g., an incomplete match, frame total exceeding 10 pins, or wrong amount of bonus rolls in the 10th frame).

```json
{
  "success": false,
  "message": "Frame cannot exceed 10 pins.",
  "data": null
}
```

500 - Server Error
```json
{
  "success": false,
  "message": "Unexpected server error",
  "data": null
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

Live UI Web App: https://bowling-game-scoreboard.web.app/

## Author

Izabella Costa
