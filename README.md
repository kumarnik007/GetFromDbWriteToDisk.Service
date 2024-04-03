# GetFromDbWriteToDisk.Service Application

This application gets a set of documents from SQL database. The documents are details about some files or attachments which are stored in the database. The binary data for these files, once retrieved can then be written to file created on local disk storage.

There are 2 API endpoints :

```sh
`GET /api/documents` : GETS all documents from SQL database.
`POST /api/document` : This expects an ID of the document from SQL db, it will write the binary data for that document to local disk.
```

## Recommended IDE Setup

[Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)

## Project Setup

1. Clone/fork the repository.
2. Open the solution file `GetFromDbWriteToDisk.Service.sln` present at project root.
3. Put the following environment variable in the `launchSettings.json` file present at path `./Service.API/Properties/` (relative to project root path)

```sh
"CONNECTION_DB_NAME" : <Name of the database to connect to>
"CONNECTION_DB_TABLE" : <Name of the table to connect within the database>
```

4. Ensure the table mentioned in step(3) has column names as required by class `Service.Models/Schemas/Document.cs`
5. Start the application from visual studio using one of the launch profiles (which now contains the environment variables)
6. The application launches on swagger UI, which can be used to test the APIs.
