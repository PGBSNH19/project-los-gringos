﻿FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app

COPY VirtPub/*.csproj ./VirtPub
RUN dotnet restore

COPY ./VirtPub ./VirtPub
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "VirtPub.dll"]
