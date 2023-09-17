# worktitle
Рабочее название

## Миграции
### Создание новой миграции
```
dotnet ef migrations add "InitDatabase" --context WorkTitleContext --project src\Infrastructure\WorkTitle.Infrastructure.PostgreSql\WorkTitle.Infrastructure.PostgreSql.csproj --startup-project src\WorkTitle\WorkTitle.Api.csproj
```
## Создание секретов
### Создание секрета PostgresPassword
```
dotnet user-secrets set "PostgresPassword" "Your password" --project src\WorkTitle
```
