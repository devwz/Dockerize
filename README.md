# Dockerize

Tutorial de utilização do Docker em uma aplicação .NET Core e banco de dados Sql Server

## Iniciando

Crie a aplicação .NET Core normalmente com o banco de dados Sql Server

## Docker

Adicione o Dockerfile na pasta da solução

Inicie uma instância do Sql Server no Docker

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password" -p 1433:1433 --name sqldata -d microsoft/mssql-server-linux
```

Compile e rode a aplicação utilizando o Link para conecta-la com o Sql Server

```sh
docker build -t dotnetcore .

docker run -d -p 57877:80 --link sqldata --name dotnetcore dotnetcore
```