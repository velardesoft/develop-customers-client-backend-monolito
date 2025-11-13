# Usa el SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

# Usa la imagen base de runtime de ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Define el puerto y endpoint
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Copia el build
COPY --from=build /app .

# Arranca tu app publicada
ENTRYPOINT ["dotnet", "u20211c221.dll"]
