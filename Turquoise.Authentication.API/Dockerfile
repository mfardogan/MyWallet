#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Turquoise.Authentication.API/Turquoise.Authentication.API.csproj", "Turquoise.Authentication.API/"]
RUN dotnet restore "Turquoise.Authentication.API/Turquoise.Authentication.API.csproj"
COPY . .
WORKDIR "/src/Turquoise.Authentication.API"
RUN dotnet build "Turquoise.Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Turquoise.Authentication.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Turquoise.Authentication.API.dll"]