FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Auther.API/Auther.API.csproj Auther.API/
RUN dotnet restore Auther.API/Auther.API.csproj
COPY . .
WORKDIR /src/Auther.API
RUN dotnet build Auther.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Auther.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Auther.API.dll"]
