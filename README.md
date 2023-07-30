# thulir

```
nvm list
nvm use v16.20.1
```

```
cd thulir
git pull
dotnet restore
dotnet publish -r linux-x64 -o ~/ThulirWeb
```


```
export ASPNETCORE_URLS="http://*:80;https://*:443"
export FILE_UPLOAD_FOLDER_NAME=/tmp/uploads/
export S3_CACHE_FOLDER=/tmp/uploads/s3Cache/

mkdir /tmp/uploads

# Permissions to listen on Port 80, 443
sudo setcap cap_net_bind_service=+ep ~/ThulirWeb/Thulir.ReactUI


# Run the exe
cd ~/ThulirWeb
./Thulir.ReactUI
```