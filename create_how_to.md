# How to manually create image

## Linux

### 1. Build

``` cmd
docker build -t sheyenrath/blazor-webassembly-filehash-fixer .
```

### 2. Delete dangling images

``` ps
docker rmi $(docker images -f "dangling=true" -q)
```

### 3. Push

``` cmd
docker push sheyenrath/blazor-webassembly-filehash-fixer
```


 dotnet publish -c Release -r linux-x64 -o ../../out --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true