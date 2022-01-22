```shell
nvm use node 16

dotnet restore

dotnet publish -r linux-x64 -o ~/ThulirCrawler

cd ~/ThulirCrawler
./Thulir.Weather.Crawler
```
