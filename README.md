# Todo List SPA
  A todo list app written with ASP.NET Core SPA with React bundled with Vite.

## Requirements

You'll need:
* npm or yarn. If you're using yarn, then you'll need to update the .csproj file to use yarn instead of npm.
* .NET 7 SDK with your IDE of choice.
* An instance of SQL Server to connect to. You can utilize SQL LocalDB for testing purposes.
  * If you want to switch to another DB provider, you need to install the relevant NuGet package and change the DbContext option in Program.cs. You'll also need to delete the Migrations folder and regenerate the migrations for your particular DB.

## API Setup

> Do this first!

1. Clone this repo
2. Restore the NuGet packages
    ```
    dotnet restore
    ```
3. Run the secrets manager init method to update the project's SecretId
   ```
   dotnet user-secrets init
   ```
4. Copy the content of `appsettings.Example.json` to the secrets file and tweak as needed.
   1. Windows: `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`
   2. Linux/macOS: `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`
5. Run the DB Seed routine to populate the DB with sample data
   ```
   dotnet run seed=True
   ```

## Front-end SPA Setup

1. Change directory into the `ClientApp` folder.
2. Restore packages.
   1. NPM:
   ```
   npm install
   ```
   2. Yarn:
   ```
   yarn
   ```

## Running the application

> Make sure you've done API Setup and Front-end SPA Setup first!


Ensure that you're in the repo's root and run
```
dotnet run
```

This will start the development server listening on [http://localhost:5001](https://localhost:5001). Upon receiving a request, it will automatically launch Vite and spin up the frontend site. **Note**: Closing the `dotnet` process will also abort vite, but not vice-versa!

## Accessing Swagger Endpoint

You can find the swagger endpoint at [http://localhost:5001/swagger](https://localhost:5001/swagger). From here, you can test-drive the API endpoints.

## LICENSE

This project is licensed under the [MIT License](./LICENSE).

## Contributing

Please feel free to submit pull requests or fork this repo!

## Author

Robert Cato <[saiwolf@swmnu.net](mailto:saiwolf@swmnu.net)>
