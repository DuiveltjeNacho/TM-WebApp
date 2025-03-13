# Use official .NET 8 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use .NET 8 SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskManagerWebApp.csproj", "./"]
RUN dotnet restore "TaskManagerWebApp.csproj"
COPY . .
RUN dotnet publish "TaskManagerWebApp.csproj" -c Release -o /app/publish

# Final stage: Run the application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TaskManagerWebApp.dll"]
