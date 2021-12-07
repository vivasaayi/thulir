```shell
export PATH=/home/ec2-user/.dotnet:$PATH
export ASPNETCORE_URLS="http://*:80;https://*:443"

cd thulir
dotnet publish -r linux-x64 -o ~/ThulirWeb

cd ~/ThulirWeb
sudo setcap cap_net_bind_service=+ep ~/ThulirWeb/Thulir.ReactUI
./Thulir.ReactUI
```
