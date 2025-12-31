# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Calculadora.sln ./
COPY CalculadoraAPI/*.csproj CalculadoraAPI/
COPY CalculadoraAPI.Tests/*.csproj CalculadoraAPI.Tests/

RUN dotnet restore

COPY . ./
WORKDIR /app/CalculadoraAPI
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:80

ENTRYPOINT ["dotnet", "CalculadoraAPI.dll"]
