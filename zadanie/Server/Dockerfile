FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY PicturePortal.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PicturePortal.dll"]
