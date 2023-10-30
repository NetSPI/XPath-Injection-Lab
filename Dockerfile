#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookSearchApp.csproj", "."]
RUN dotnet restore "./BookSearchApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BookSearchApp.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "BookSearchApp.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "BookSearchApp.dll"]