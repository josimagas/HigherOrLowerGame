# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

LABEL author="José Magalhães"


WORKDIR /source
COPY . .

RUN dotnet restore "HigherOrLowerGame.Api/HigherOrLowerGame.Api.csproj" 
RUN dotnet publish "HigherOrLowerGame.Api/HigherOrLowerGame.Api.csproj" -c release -o /app --no-restore

#Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as runtime
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT [ "dotnet", "HigherOrLowerGame.Api.dll" ]