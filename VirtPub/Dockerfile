﻿FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App

COPY VirtPub/*.csproj ./
RUN dotnet restore

COPY VirtPub/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "VirtPub.dll"]
