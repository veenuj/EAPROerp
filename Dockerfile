# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY . .
RUN dotnet restore

# Build and publish the release
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 (Render's default port for web services)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# START THE APP
ENTRYPOINT ["dotnet", "EaproERP.dll"]