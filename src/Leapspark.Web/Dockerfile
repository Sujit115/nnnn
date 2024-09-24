FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN ls
RUN dotnet publish Leapspark.Web.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Leapspark.Web.dll"]