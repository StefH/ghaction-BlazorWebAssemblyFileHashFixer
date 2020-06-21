# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env

# LABEL maintainer="Stef Heyenrath"

# WORKDIR /app

# copy csproj and restore as distinct layers
# COPY BlazorWebAssemblyFileHashFixer.csproj ./
# RUN dotnet restore

# copy everything else and build
# COPY *.cs ./

# RUN dotnet publish -c Release -r linux-x64 -o out --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true

# build runtime image
# FROM mcr.microsoft.com/dotnet/core/runtime:3.1-bionic
# WORKDIR /app
# COPY --from=build-env /app/out ./
# RUN chmod +x ./fixer
# ENTRYPOINT ["./fixer"]

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-bionic

LABEL maintainer="Stef Heyenrath"

# Copies your code file from your action repository to the filesystem path `/` of the container
COPY ./out/fixer fixer

RUN chmod +x ./fixer

# Code file to execute when the docker container starts up (`entrypoint.sh`)
ENTRYPOINT ["/fixer"]