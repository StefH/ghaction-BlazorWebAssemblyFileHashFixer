FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env

LABEL maintainer="Stef Heyenrath"

WORKDIR /app

COPY BlazorWebAssemblyFileHashFixer.csproj ./
COPY *.cs ./
COPY *.json ./

RUN dotnet publish -c Release -r linux-x64 -o out --self-contained true -p:PublishSingleFile=true

RUN ls -al
RUN ls -al out

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-bionic
WORKDIR /app
COPY --from=build-env /app/out/fixer /fixer
RUN chmod +x /fixer
ENTRYPOINT ["/fixer"]