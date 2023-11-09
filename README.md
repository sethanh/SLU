# SLU

## 1. Migrate database and seed data

- Create MySql user with username `easysalon` and password `ctnet@1812`. Grant DBA permission to this user.

- Run following command, CHOSE ONE - NOT BOTH:

```bash
# Visual Studio - Nuget Package Manager Console
update-database

# Or dotnet CLI - For non VS developer
cd ./MIGRATION
dotnet ef database update
```

## 2. Run apps
- Run `MAIN` for management api
- Run `CUSTOMER` for customer app api
