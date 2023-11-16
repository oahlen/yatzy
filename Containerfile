FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime

WORKDIR /app
COPY publish /app

ENTRYPOINT [ "dotnet", "Yatzy.Server.dll" ]
