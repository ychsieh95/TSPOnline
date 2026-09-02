<!-- markdownlint-disable MD041 -->
**English** | [繁體中文](README.zh-TW.md)

# TSPOnline

![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4)
![License: CC BY-NC-SA 4.0](https://img.shields.io/badge/License-CC%20BY--NC--SA%204.0-lightgrey)

TSPOnline is a community-maintained resource site for **吞食天地完美版** (Tun Shih Tien Ti — Complete Edition), a Taiwanese Romance-of-the-Three-Kingdoms-themed online game. It catalogs monsters, pets, equipment, materials, ores, missions, maps, and other in-game data for players.

**[Live Demo](https://tsp.holey.cc)**

![Homepage](https://imgur.com/zhrT8Zo.png)

## Table of Contents

* [Content Disclaimer](#content-disclaimer)
* [Content License](#content-license)
* [Tech Stack](#tech-stack)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Configuration](#configuration)
  * [Database](#database)
  * [Running Locally](#running-locally)
* [Project Structure](#project-structure)
* [Deployment](#deployment)
  * [Docker](#docker)
* [Contributing](#contributing)
* [References](#references)

## Content Disclaimer

The in-game data presented on this site is compiled from the sources listed under [References](#references), with minor edits for accuracy and readability (typo fixes, wording polish). No ownership over the original game or its assets is claimed.

If any content on the site infringes on your rights, please open a Pull Request or contact [ychsieh95@gmail.com](mailto:ychsieh95@gmail.com) — the content in question will be taken down immediately upon notice.

## Content License

Except for content with an explicitly marked source (such as some character illustrations), all content on the site is licensed under **CC BY-NC-SA 4.0**.

![CC BY-NC-SA 4.0](https://i.creativecommons.org/l/by-nc-sa/4.0/80x15.png)

The full scope and terms of the license are listed on the site itself.

## Tech Stack

| Layer | Technology |
| --- | --- |
| Framework | ASP.NET Core 10.0 (Razor Pages, Runtime Compilation) |
| Data access | [Dapper](https://github.com/DapperLib/Dapper) over SQLite (`files/database/tsponline.db`) |
| Front-end libraries | Managed via [LibMan](https://learn.microsoft.com/aspnet/core/client-side/libman/) — jQuery, Bootstrap, Bootstrap Toggle, Font Awesome |
| Deployment | Docker / Docker Compose |

## Getting Started

### Prerequisites

* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* [Docker](https://docs.docker.com/get-docker/) — only for the container workflow described under [Deployment](#deployment)

### Configuration

The checked-in `appsettings.json` holds nothing but the local SQLite connection string and contains no secrets; `appsettings.example.json` keeps a reference copy of the same shape.

To override settings, use environment variables or an environment-specific `appsettings.{Environment}.json` — for example `appsettings.Development.json`, which ASP.NET Core loads automatically when `ASPNETCORE_ENVIRONMENT=Development` (the value set by the launch profile) and which Git ignores. In environment variables, nested keys are separated by double underscores:

```bash
ConnectionStrings__DefaultConnection='Data Source=/data/tsponline.db' dotnet run
```

### Database

No manual database setup is required. On startup the application resolves the configured `Data Source` against the content root, creates the containing directory, and — if the database file does not exist yet — copies the bundled `files/database/tsponline.seed.db` into place so the site starts with the reference data. The schema is then applied with `CREATE TABLE IF NOT EXISTS`, so a missing seed simply leaves you with an empty database that still has the correct tables.

The generated runtime database and its SQLite sidecar files are excluded from Git; only the seed is tracked.

### Running Locally

```bash
dotnet restore
dotnet run
```

By default, the app starts at `https://localhost:5001` and `http://localhost:5000` (see `Properties/launchSettings.json` for the full profile configuration).

## Project Structure

```text
├── Docker/           # Dockerfile and Compose configuration
├── Extensions/       # Extension methods
├── HtmlGenerator/    # Custom HTML generators (e.g. alert messages)
├── Infrastructure/   # Startup infrastructure (database initialization and schema)
├── Interfaces/       # Repository interface definitions
├── Models/           # Data models and settings
├── Pages/            # Razor Pages, grouped by resource type (Monsters, Pets, Equipments, ...)
├── Properties/       # Local launch profiles
├── Repositorys/      # Data access layer (Dapper)
├── files/database/   # Bundled seed database and the generated runtime database
├── wwwroot/          # Static assets (images, LibMan-managed front-end libraries)
├── Program.cs        # Entry point and request pipeline configuration
├── appsettings.json  # Default configuration (local SQLite connection string)
├── libman.json       # LibMan front-end library manifest
└── TSPOnline.csproj
```

## Deployment

### Docker

Build the image from the repository root:

```bash
docker build -t tsp-holey-cc -f Docker/Dockerfile .
```

Run the container:

```bash
docker run -d -p 8080:8080 --name tsponline tsp-holey-cc
```

The container listens on port `8080`. The image runs as the non-root user identified by the .NET base image's `APP_UID` (`1654` for the .NET 10 Linux images used here), and the publish output is owned by that user so the runtime database can be initialized safely.

Or use the included Compose configuration, which builds from the repository root and persists the runtime database in the local `files/database` directory:

```bash
docker compose -f Docker/compose.yaml up -d
```

Never commit production secrets or a runtime database. If a secret has ever been committed, remove it from the active configuration and rotate it; adding the file to `.gitignore` does not remove it from Git history.

## Contributing

Contributions of game data, bug reports, and general suggestions are welcome. Please open a Pull Request, or email [ychsieh95@gmail.com](mailto:ychsieh95@gmail.com) directly. Thanks for your help!

## References

* [吞食伊拉克](http://shota.ddns.net/)
* [DODO刷NPC大全集 - TS SOS](http://15963578.blogspot.tw/p/ctrlf.html)
* [吞食天地 On-Line - 巴哈姆特](https://forum.gamer.com.tw/A.php?bsn=5334)
