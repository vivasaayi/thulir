// See https://aka.ms/new-console-template for more information

using System;
using Thulir.Weather.Crawler.Services;

Console.WriteLine("Hello, from the crawler!");

CrawlerService crawlerService = new CrawlerService();

crawlerService.Init();
await crawlerService.Start();

Console.WriteLine("Program Exiting...");