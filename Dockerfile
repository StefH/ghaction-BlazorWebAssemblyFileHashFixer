#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["src/BlazorWebAssemblyFileHashFixer/BlazorWebAssemblyFileHashFixer.csproj", "src/BlazorWebAssemblyFileHashFixer/"]
RUN dotnet restore "src/BlazorWebAssemblyFileHashFixer/BlazorWebAssemblyFileHashFixer.csproj"
COPY . .
WORKDIR "/src/src/BlazorWebAssemblyFileHashFixer"
RUN dotnet build "BlazorWebAssemblyFileHashFixer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorWebAssemblyFileHashFixer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorWebAssemblyFileHashFixer.dll"]