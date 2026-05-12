# Base image - lightweight for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image - heavy lifting
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FragTracker.csproj", "./"]
RUN dotnet restore "FragTracker.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "FragTracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FragTracker.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage - let the frags begin
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FragTracker.dll"]
