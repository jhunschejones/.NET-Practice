# .NET To-Do List For New Relic

This application is a .NET Core MVC web application with a back end API and a basic user interface. The database is stored temporarily in memory for the purposes of allowing the app to spin up in several different test environments.

For purposes of testing distributed tracing and external calls, there are also two additional endpoints available that make an external API call before returning data:
* `/api/weather/portland`
*`/api/weather/dublin`

Run locally by hitting `F5` in VS Code

### Instructions for running the app with Dockerfile
0. `dotnet publish --runtime debian-x64`
1. `docker build . -t todoapi`
2. `docker run -d -p 5005:5005 --name todoapi todoapi`
3. Go to `localhost:5005` to access the app in a web browser. *(Also try `/api/weather` for info on some additional fun endpoints!)*

### Other Commands:
* To list the process ID: `docker ps`
* To remove the container: `docker rm -f [container ID]`
