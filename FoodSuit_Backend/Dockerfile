FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FoodSuit_Backend/FoodSuit_Backend.csproj", "FoodSuit_Backend/"]
RUN dotnet restore "FoodSuit_Backend/FoodSuit_Backend.csproj"
COPY . .
WORKDIR "/src/FoodSuit_Backend"
RUN dotnet build "FoodSuit_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FoodSuit_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodSuit_Backend.dll"]
