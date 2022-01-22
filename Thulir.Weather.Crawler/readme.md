```shell
nvm use node 16

cd ~/thulir/Thulir.Weather.Crawler/
dotnet restore

dotnet publish -r linux-x64 -o ~/ThulirCrawler

cd ~/ThulirCrawler
./Thulir.Weather.Crawler
```
