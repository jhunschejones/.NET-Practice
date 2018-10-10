# .NET To-Do and Weather

.NET To-Do and Weather is a simple .NET Core application with API endpoints to test the new NR Wanda UI.

## Description
This application is part of the [Wanda Sandbox Environment Project](https://source.datanerd.us/tech-support/support-demo). It was designed to provide a sample .NET Core app that reports data to the New Relic RPM for the purpose of testing by the Support Teams. The app has been containerized using [Docker](https://www.docker.com/), and can be built and run as a standalone app for .NET Core Agent testing by Support, as well as in the Sandbox Environment.

## Primary Features
- [x] Custom API Endpoints
- [x] Containerized using [Docker](https://www.docker.com/)
- [x] **{External API's}**
- [x] **{Framework's}**

## API Endpoints
The application will start a local dev server at `0.0.0.0:{port}`
### Routes
- `/api/route` expects a **{format}** **{http_method}** with **{data}**

You can test these endpoints using [Postman](https://www.getpostman.com/apps).

## Requirements

### Docker
Donwload and install [Docker Community Edition](https://store.docker.com/search?type=edition&offering=community) for your Operating System.

## Installation
You can download the source code by clicking on the **Clone or Dropdown** menu above, then clicking **Download as Zip**.

Alternatively you can download via Git. If you don't already have Git installed, download it from [here](git-scm.com). Install the version for your operating system.

### Fetch the Source Code

From the terminal, run:
```sh
$ git clone https://source.datanerd.us/{project_route}
```

## How to run this project
 * Open a **Terminal**
 * `cd` into the project folder
 * Run `docker build -f Dockerfile -t {app_name} .`
 * Run `docker run --rm -it -p {port}:{port} {app_name}`