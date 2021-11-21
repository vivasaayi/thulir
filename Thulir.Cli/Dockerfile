FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Thulir.Cli/Thulir.Cli.csproj", "Thulir.Cli/"]
RUN dotnet restore "Thulir.Cli/Thulir.Cli.csproj"
COPY . .
WORKDIR "/src/Thulir.Cli"
RUN dotnet build "Thulir.Cli.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Thulir.Cli.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thulir.Cli.dll"]
