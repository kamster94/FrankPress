# FrankPress

This application is simple, cross-platform CMS with backend written in ASP.NET 6 and frontend written in Vue.js, with data persisted in Microsoft SQL Server. All three layers are separate docker containers, run by single docker compose file. API layer utilizes Entity Framework Core as ORM.

It is more of a proof of concept and personal exercise rather than complete product, but the goal is to run it live on a server one day. If you find an issue, want to create pull request, comment on one, or fork the project, you are more than welcome to do it.

## Running the application

- To run the application locally, make sure you have Docker installed on your machine (preferably with WSL2 if you are on Windows).
- Create `secrets` folder in root directory. Inside, create all secret files referenced in docker-compose file, and populate them with appropriate secrets.
- If you open the solution in Visual Studio, it should create and run docker containers automatically.
- Launching the solution for the first time, or after purging data volume for database requires running EF Core migrations. This can be done using those steps:
  1. Make sure you have ConnectionString secret set in user secrets for Web project, using 'localhost' as server, not mssql container name. Migrations will run using your host, not docker container.
  2. Set Web as startup project.
  3. Use Packer Manager Console to run command `Update-Database`, or make sure you have installed EF Core CLI tools and run `dotnet ef database update` in console. You can read more about creating and running migrations in EF Core [here](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli).
  4. If you experience connection problems, make sure your connection string is correct and that mssql container is running and FrankPress database is created.
  5. After running migrations you can connect to the database and verify all tables are created correctly.
  6. If migrations run successfully, remember to switch startup project back to docker compose.
- For setting up authentication service, see Auth0 section.
- Fill in `appsettings.Development.json` file, providing all necessary secrets into appropriate sections.
- Fill in `vue/.env` file, providing details from your Auth0 services and any other necessary key referenced there.
- I recommend running the app using docker-compose profile, it'll automatically grab container started by Visual Studio and run application in it.

## Auth0 authentication service

- This solution uses Auth0 service as authentication provider.
- To run this, you'll need a free account from this site: https://auth0.com/.
- To run this app, you need to create one application (with SPA profile), and one API.
- Follow guides provided in Auth0 dashboard to find all relevant settings and populate appropriate secrets.

## Sentry logging and telemetry

- This app utilizes Sentry service to gather logs and requests performance.
- To use it you'll need a free account from this site: https://sentry.io.
- Remember to fill `Dsn` key in `Sentry` section of `appsettings.Development.json` using value from Sentry platform.
- If you've configured everything properly, you should see logs from app gathered by Sentry in the dashboard.
- If you have problems or questions regarding Sentry, check documentation at: https://docs.sentry.io/.

### Credits

- Parts of SQL Server service creation scripts and docker file copied from https://github.com/thirdgen88/mssql-docker were created by Kevin Collins and Rytis Ilciukas.
- TypeScript implementation of Auth0 wire up comes from https://github.com/alexeyzimarev/auth0-vue3-ts and was created by Alexey Zimarev.
