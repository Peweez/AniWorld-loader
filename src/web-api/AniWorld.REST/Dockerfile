#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AniWorld.REST/AniWorld.REST.csproj", "AniWorld.REST/"]
RUN dotnet restore "AniWorld.REST/AniWorld.REST.csproj"
COPY . .
WORKDIR "/src/AniWorld.REST"
RUN dotnet build "AniWorld.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AniWorld.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AniWorld.REST.dll"]