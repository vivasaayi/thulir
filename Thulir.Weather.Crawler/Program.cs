using System;
using Thulir.Core.Dals;
using Thulir.Core.Models;
using Thulir.Core.Repositories;
using Thulir.Core.Utils;
using Thulir.Weather.Crawler.Services;
using Thulir.Weather.Models.OpenWeather;
using Thulir.Weather.Repositories;

Console.WriteLine("Starting Crawler...");
Console.WriteLine("Initializing ConfigLoader");

await ConfigLoader.GetInstance().Init();

ThulirGlobals globals = await ConfigLoader.GetInstance().GetGlobals();

PostgresDal.Init(new PostgresConfig(
    globals.PostgresHost,
    globals.PostgresUserName,
    globals.PostgresPassword,
    globals.PostgresDatabase)
);

CrawlerService crawlerService = new CrawlerService();

crawlerService.Init();
await crawlerService.Start();

Console.WriteLine("Program Exiting...");