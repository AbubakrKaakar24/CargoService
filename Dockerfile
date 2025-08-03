# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy solution and project files
COPY ["CargoService.sln", "./"]
COPY ["CargoService/CargoService.API.csproj", "CargoService/"]
COPY ["CargoService.Application/CargoService.Application.csproj", "CargoService.Application/"]
COPY ["CargoService.Domain/CargoService.Domain.csproj", "CargoService.Domain/"]
COPY ["CargoService.Infrastructure/CargoService.Infrastructure.csproj", "CargoService.Infrastructure/"]

# Restore NuGet packages for the API project
RUN dotnet restore "CargoService/CargoService.API.csproj"

# Copy all files
COPY . .

WORKDIR "/src/CargoService"
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "CargoService.API.dll"]
