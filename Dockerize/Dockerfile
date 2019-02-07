FROM microsoft/dotnet:2.2-aspnetcore-runtime As base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk As build
WORKDIR /src
COPY Dockerize/Dockerize.csproj Dockerize/
COPY Dockerize.Core/Dockerize.Core.csproj Dockerize.Core/
RUN dotnet restore Dockerize/Dockerize.csproj
COPY . .
WORKDIR /src/Dockerize
RUN dotnet build Dockerize.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Dockerize.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dockerize.dll"]