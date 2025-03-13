# Use the official .NET SDK image from Microsoft
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK for building and restoring dependencies
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskManagerWebApp/TaskManagerWebApp.csproj", "TaskManagerWebApp/"]
RUN dotnet restore "TaskManagerWebApp/TaskManagerWebApp.csproj"
COPY . .
WORKDIR "/src/TaskManagerWebApp"
RUN dotnet build "TaskManagerWebApp.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "TaskManagerWebApp.csproj" -c Release -o /app/publish

# Final stage: set up the app in the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagerWebApp.dll"]