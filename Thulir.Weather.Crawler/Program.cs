// See https://aka.ms/new-console-template for more information

using System;
using Thulir.Weather.Crawler.Services;

Console.WriteLine("Hello, World!");

CrawlerService crawlerService = new CrawlerService();

crawlerService.Init();
crawlerService.Start();