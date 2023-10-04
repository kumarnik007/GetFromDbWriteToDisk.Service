using Service.Models.Contexts;
using Service.Models.Schemas;
using Service.Utils;

namespace Service.API.Endpoints
{
    public class Documents
    {
        private static List<Document>? _allDocuments;

        /// <summary>
        /// Maps all the API endpoints.
        /// </summary>
        /// <param name="app"></param>
        public static void Endpoints(WebApplication app, IConfiguration config)
        {
            GetDocuments(app);
            WriteToDisk(app, config);
        }

        /// <summary>
        /// Configures the service to handle GET requests for documents.
        /// </summary>
        /// <remarks>
        /// This method maps a GET endpoint to retrieve all documents.
        /// It returns an HTTP 200 response with the documents, if found.
        /// It returns an HTTP 404 response if no documents are found.
        /// </remarks>
        /// <param name="app">This is the <see cref="WebApplication"/> object.</param>
        ///
        public static void GetDocuments(WebApplication app)
        {
            app.MapGet("/api/documents", (DocumentContext context) =>
            {
                var documents = context.DbDocumentModel.ToList();
                Console.WriteLine($"Number of documents are {documents.Count}");

                if (documents is null)
                    return Results.NotFound("No invoices in db");

                _allDocuments = documents;

                return Results.Ok(documents);
            })
            .WithTags("Documents");
        }

        /// <summary>
        /// Configures the service to write the data of document to a file
        /// on disk.
        /// </summary>
        /// <param name="app">This is the <see cref="WebApplication"/> object.</param>
        /// <param name="config">This is the <see cref="IConfiguration"/></param>
        public static void WriteToDisk(WebApplication app, IConfiguration config)
        {
            app.MapPost("/api/documents", (int documentId) =>
            {
                if (_allDocuments == null)
                {
                    return Results.BadRequest("Get all Documents before trying to write to disk");
                }

                var currentDocument = _allDocuments.Find(d => d.DocumentId == documentId);

                if (currentDocument is null)
                {
                    return Results.NotFound($"Document with documentId {documentId} not found.");
                }

                if (!currentDocument.Type.Equals("text/plain")
                    && !currentDocument.Type.Equals("text/html"))
                {
                    return Results.Problem($"Writing file of type {currentDocument.Type} is not supported.");
                }

                try
                {
                    var filePath = config.GetValue<string>("OutputFilePath") + $"/{currentDocument.DocumentId}";

                    if (currentDocument.Type.Equals("text/plain"))
                    {
                        filePath += ".txt";
                        DiskWriter.WriteTextFile(currentDocument.Data, filePath);
                    }

                    if (currentDocument.Type.Equals("text/html"))
                    {
                        filePath += ".html";
                        DiskWriter.WriteHtmlFile(currentDocument.Data, filePath);
                    }

                    return Results.Created($"/api/documents/{documentId}", filePath);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .WithTags("Documents");
        }
    }
}
