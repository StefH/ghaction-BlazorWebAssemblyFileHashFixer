FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env

LABEL maintainer="Stef Heyenrath"

WORKDIR /app

# copy csproj and restore as distinct layers
COPY BlazorWebAssemblyFileHashFixer.csproj ./
RUN dotnet restore

# copy everything else and build
COPY *.cs ./

RUN dotnet publish -c Release -r linux-x64 -o out --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true

# build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-bionic
WORKDIR /app
COPY --from=build-env /app/out ./
RUN chmod +x ./fixer
ENTRYPOINT ["./fixer"]