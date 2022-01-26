// See https://aka.ms/new-console-template for more information

using System;
using Thulir.Core.Dals;
using Thulir.Core.Repositories;
using Thulir.Weather.Crawler.Services;
using Thulir.Weather.Models.OpenWeather;
using Thulir.Weather.Repositories;

Console.WriteLine("Hello, from the crawler!");

PostgresDal.Init(new PostgresConfig("thulir-db.ctvluakn5fyn.us-west-2.rds.amazonaws.com", 
    "postgres", 
    "rajanpanneer", 
    "postgres"));

UsersRepository ur = new UsersRepository();
await ur.GetAllUsers();

IWeatherRepository wr = new WeatherRepository(PostgresDal.GetInstance());
await wr.GetCurrentWeather("123");
await wr.SaveCurrentWeather(new OneCallAPIResponse());


CrawlerService crawlerService = new CrawlerService();

crawlerService.Init();
await crawlerService.Start();

Console.WriteLine("Program Exiting...");