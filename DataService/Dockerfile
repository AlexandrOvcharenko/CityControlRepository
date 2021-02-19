FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY DataService.csproj DataService.csproj
RUN dotnet restore DataService.csproj
COPY . .
WORKDIR /src
RUN dotnet build DataService.csproj -c Release -o /app
FROM build AS publish
RUN dotnet publish DataService.csproj -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataService.dll"]