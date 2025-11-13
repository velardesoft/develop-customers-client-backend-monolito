# 1) Imagen base de runtime de ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Exponiendo el puerto recomendado por Railway (puedes usar 8080 o tomarlo de la variable de entorno)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# 2) Imagen base de SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia el código fuente completo al contenedor (usa contexto adecuado)
COPY . .
# Publica tu proyecto
RUN dotnet publish -c Release -o /app

# 3) Imagen final solo con runtime + tu app publicada. Minimiza tamaño y vulnerabilidades.
FROM base AS final
WORKDIR /app
COPY --from=build /app .

# Establece el entrypoint
ENTRYPOINT ["dotnet", "u20211c221.dll"]
