FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /BackendApp

COPY *csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o backendout

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /BackendApp
COPY --from=build-env /BackendApp/backendout .
ENTRYPOINT ["dotnet", "VertPub.Backend.dll"]
