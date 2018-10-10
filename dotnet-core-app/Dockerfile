FROM microsoft/dotnet:2.1.403-sdk-stretch

ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-netcore20-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-netcore20-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=85168d0cd8298c58f66ff6d742281a61efd79c43 \
NEW_RELIC_APP_NAME=ToDoApi2

WORKDIR /app

ARG runtimeIdentifier=debian-x64
ARG files=./bin/Debug/netcoreapp2.1/$runtimeIdentifier/publish
COPY $files ./appcode

# Dowloads the new relic installer during launch
RUN echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget -O- https://download.newrelic.com/548C16BF.gpg | apt-key add - \
&& apt-get update \
&& apt-get install newrelic-netcore20-agent

ENV ASPNETCORE_URLS http://+:5005
EXPOSE 5005

WORKDIR /app/appcode
ENTRYPOINT ["dotnet", "TodoApi.dll"]