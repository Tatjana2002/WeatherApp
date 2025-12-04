# 1. Build stage – koristi Windows .NET Framework SDK da izgradi projekat
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /src

# Kopiramo sve fajlove iz tvog projekta u container
COPY . .

# Build projekta (Release)
RUN msbuild AplikacijaVremenskePrognoze.sln /p:Configuration=Release

# 2. Runtime stage – IIS + .NET Framework 4.8
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8
WORKDIR /inetpub/wwwroot

# Kopiramo buildovane fajlove u IIS folder
COPY --from=build /src/AplikacijaVremenskePrognoze/bin/Release/ .