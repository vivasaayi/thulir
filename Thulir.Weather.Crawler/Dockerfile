FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Thulir.Weather.Crawler/Thulir.Weather.Crawler.csproj", "Thulir.Weather.Crawler/"]
RUN dotnet restore "Thulir.Weather.Crawler/Thulir.Weather.Crawler.csproj"
COPY . .
WORKDIR "/src/Thulir.Weather.Crawler"
RUN dotnet build "Thulir.Weather.Crawler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thulir.Weather.Crawler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thulir.Weather.Crawler.dll"]
