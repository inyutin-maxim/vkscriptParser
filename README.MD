Для публикации проекта выполните:
```
dotnet publish -c Release -o ./bin/Docker -r linux-x64
```

Для сборки dockerfile выполнтие в терминале:

```
docker build --build-arg source=. -t reo-identity-server-mvc .
```

для запуска контейнера

```
docker run -p 5000:80 --name reo-identity-server-mvc -t -i reo-identity-server-mvc:latest 
```

Для разработки можно использовать postgres из docker
```
docker run --name dev-postgres -e POSTGRES_PASSWORD=QAZ1qaz -d postgres
``` 

# Миграции
Для выполнения накатывания новой миграции используйте следующую команду
### IdentityContext
```bash
 dotnet ef migrations add -o Data/Migrations/IdentityServer/IdentityDb -p Reo.IdentityServer -c IdentityContext Initial
```

### ConfigurationDbContext
```bash
 dotnet ef migrations add -o Data/Migrations/IdentityServer/ConfigurationDb -p Reo.IdentityServer -c ConfigurationDbContext Initial
```

### PersistedGrantDbContext

```bash
 dotnet ef migrations add -o Data/Migrations/IdentityServer/PersistedGrantDb -p Reo.IdentityServer -c PersistedGrantDbContext Initial
```