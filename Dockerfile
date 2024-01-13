FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY Src/Domain/Domain.csproj Src/Domain/
COPY Src/Shared/Shared.csproj Src/Shared/
COPY Src/Types/Types.csproj Src/Types/
COPY Src/Forge/Forge.csproj Src/Forge/
COPY Src/CQRS/CQRS.csproj Src/CQRS/
COPY Src/WebAPI/WebAPI.csproj Src/WebAPI/

RUN dotnet restore Src/WebAPI/WebAPI.csproj -r linux-x64
COPY . .

RUN dotnet build Src/Domain/Domain.csproj -c Release -o out/Domain
RUN dotnet build Src/Shared/Shared.csproj -c Release -o out/Shared
RUN dotnet build Src/Types/Types.csproj -c Release -o out/Types
RUN dotnet build Src/Forge/Forge.csproj -c Release -o out/Forge
RUN dotnet build Src/CQRS/CQRS.csproj -c Release -o out/CQRS
RUN dotnet build Src/WebAPI/WebAPI.csproj -c Release -o out/WebAPI

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/out/WebAPI .

ENTRYPOINT ["dotnet", "WebAPI.exe"]