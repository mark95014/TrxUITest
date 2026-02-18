FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ARG CACHEBUST=1

RUN apt-get update

WORKDIR /app

COPY *.csproj ./

RUN dotnet restore
COPY . .

RUN dotnet build -c Debug

EXPOSE 4444
EXPOSE 5900

RUN env