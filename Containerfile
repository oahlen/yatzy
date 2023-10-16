FROM docker.io/node:lts-bookworm-slim AS node_base
FROM mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim AS build
COPY --from=node_base . .

WORKDIR /app
COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime

WORKDIR /app
COPY --from=build /app/publish /app

ENTRYPOINT [ "dotnet", "Yatzy.Server.dll" ]
