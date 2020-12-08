FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY VirtPub/*.csproj ./VirtPub/
RUN dotnet restore

# copy everything else and build app
COPY VirtPub/. ./VirtPub/
WORKDIR /app/VirtPub
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/VirtPub/out ./
ENTRYPOINT ["dotnet", "VirtPub.dll"]


#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
#WORKDIR /app
#COPY --from=build-env /app/out .
