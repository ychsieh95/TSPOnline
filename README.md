<!-- markdownlint-disable MD041 -->
**English** | [繁體中文](README.zh-TW.md)

# TSPOnline

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4)
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
| Framework | ASP.NET Core 8.0 (Razor Pages, Runtime Compilation) |
| Data access | [Dapper](https://github.com/DapperLib/Dapper) over SQLite (`TSPOnline/files/database/tsponline.db`) |
| Front-end libraries | Managed via [LibMan](https://learn.microsoft.com/aspnet/core/client-side/libman/) — jQuery, Bootstrap, Font Awesome, etc. |
| Deployment | Docker / Docker Compose |

## Getting Started

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Configuration

`TSPOnline/appsettings.json` holds the database connection string and Google reCAPTCHA credentials. It is intentionally excluded from version control (see `.gitignore`), so you must create it yourself before running the project. Copy the provided template and fill in your own values:

```bash
cp TSPOnline/appsettings.example.json TSPOnline/appsettings.json
```

### Running Locally

```bash
cd TSPOnline
dotnet restore
dotnet run
```

By default, the app starts at `https://localhost:5001` and `http://localhost:5000` (see `Properties/launchSettings.json` for the full profile configuration).

## Project Structure

```text
TSPOnline/
├── Extensions/       # Extension methods
├── HtmlGenerator/    # Custom HTML generators (e.g. alert messages)
├── Interfaces/       # Interface definitions
├── Models/           # Data models and settings
├── Pages/            # Razor Pages, grouped by resource type (Monsters, Pets, Equipments, ...)
├── Repositorys/      # Data access layer (Dapper)
├── files/database/   # SQLite database
└── wwwroot/          # Static assets (images, front-end libraries)
```

## Deployment

### Docker

Build the image:

```bash
docker build -t tsp-holey-cc -f Dockerfile .
```

Run the container:

```bash
docker run -d -p 8200:8080 --name tsponline tsp-holey-cc
```

Or start it via `docker-compose.yml`. This file is excluded from version control (see `.gitignore`), so you must create it yourself, for example:

```yaml
version: '3'
services:
  tsponline:
    image: tsp-holey-cc
    container_name: tsponline
    ports:
      - 8200:8080
```

```bash
docker compose up -d
```

## Contributing

Contributions of game data, bug reports, and general suggestions are welcome. Please open a Pull Request, or email [ychsieh95@gmail.com](mailto:ychsieh95@gmail.com) directly. Thanks for your help!

## References

* [吞食伊拉克](http://shota.ddns.net/)
* [DODO刷NPC大全集 - TS SOS](http://15963578.blogspot.tw/p/ctrlf.html)
* [吞食天地 On-Line - 巴哈姆特](https://forum.gamer.com.tw/A.php?bsn=5334)
