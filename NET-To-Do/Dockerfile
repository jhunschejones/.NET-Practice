FROM microsoft/dotnet:2.1-sdk

ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-netcore20-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-netcore20-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=85168d0cd8298c58f66ff6d742281a61efd79c43 \
NEW_RELIC_APP_NAME=ToDoApi

WORKDIR /app

ARG runtimeIdentifier=debian-x64
ARG files=./bin/Debug/netcoreapp2.1/$runtimeIdentifier/publish
COPY $files ./appcode

ARG NewRelic=./newrelic
# RUN mkdir -p ./newrelic
COPY $NewRelic ./newrelic

RUN dpkg -i ./newrelic/newrelic-netcore20-agent_8.6.45.0_amd64.deb

ENV ASPNETCORE_URLS http://+:80
EXPOSE 80

WORKDIR /app/appcode
ENTRYPOINT ["dotnet", "TodoApi.dll"]