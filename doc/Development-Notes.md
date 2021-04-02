# Development Notes

## Entity Framework

The following commands make use of the Entity Framework Core Tools to
to allow creating, applying and generating migrations. CLI tools can be used cross platform.

### Installation

Install tools globally

```
dotnet tool install --global dotnet-ef
```

### Create a migration

The following commands should be run in the Contact.Infrastructure folder so the project can be targeted as the source for the migration information.

### Add a migration

Add a migration called 'InitialCreate'

```
dotnet ef migrations add Initialcreate --output-dir "Data/Migrations" --namespace Data.Migrations
```

### Update the Database

Update the database defined in the connection string and migrate it to the schema defined in the initialcreate migration.

#### Direct Update

Explicitly define the connection string

```
dotnet ef database update InitialCreate -connection “Server=localhost;Database=ContactDb;User Id=sa;Password=Passw0rd”
```

#### Create an update script

Create sql script to migrate the database from blank database to the initialcreate migration.

```
dotnet ef migrations script 0 initialcreate --output Sql/Initialcreate.sql --idempotent
```

## Migration Healthcheck

Checks for any pending migrations. If none are found then healthy is returned otherwise unhealthy is returned. Useful to automate the process of checking if migrations are succesfully deployed.

The simulate a pending migration add a new property to the contact class e.g. PhoneNumber. Then run the following command. Next run the app, the health endpoint should return unhealthy for the migrations.

```
dotnet ef migrations add AddPhoneNumber --output-dir "Data/Migrations" --namespace Data.Migrations
```
