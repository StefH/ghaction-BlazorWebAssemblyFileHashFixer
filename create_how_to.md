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

### 3. Tag

``` cmd
docker tag sheyenrath/blazor-webassembly-filehash-fixer:latest sheyenrath/blazor-webassembly-filehash-fixer:2
```

### 4. Push

``` cmd
docker push sheyenrath/blazor-webassembly-filehash-fixer
```


 dotnet publish -c Release -r linux-x64 -o out --self-contained true -p:PublishSingleFile=true