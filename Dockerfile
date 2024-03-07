# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /source
COPY PremierLeaguePlayers.DataAccess/clubs.json /app/clubs.json
COPY PremierLeaguePlayers.DataAccess/players.json /app/players.json

COPY . .
RUN dotnet restore "./PremierLeaguePlayers.MinimalAPI/PremierLeaguePlayers.MinimalAPI.csproj" --disable-parallel
RUN dotnet publish "./PremierLeaguePlayers.MinimalAPI/PremierLeaguePlayers.MinimalAPI.csproj" -c release -o /app --no-restore

RUN dotnet restore "./PremierLeaguePlayers.Application/PremierLeaguePlayers.Application.csproj" --disable-parallel
RUN dotnet publish "./PremierLeaguePlayers.Application/PremierLeaguePlayers.Application.csproj" -c release -o /app --no-restore

RUN dotnet restore "./PremierLeaguePlayers.Domain/PremierLeaguePlayers.Domain.csproj" --disable-parallel
RUN dotnet publish "./PremierLeaguePlayers.Domain/PremierLeaguePlayers.Domain.csproj" -c release -o /app --no-restore

RUN dotnet restore "./PremierLeaguePlayers.DataAccess/PremierLeaguePlayers.DataAccess.csproj" --disable-parallel
RUN dotnet publish "./PremierLeaguePlayers.DataAccess/PremierLeaguePlayers.DataAccess.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "PremierLeaguePlayers.MinimalAPI.dll"]