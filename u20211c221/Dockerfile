# Usa la imagen base de runtime de ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Usa la imagen base de SDK .NET para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

# Prepara la imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "u20211c221.dll"]  

# NombreDeTuApp.dll
