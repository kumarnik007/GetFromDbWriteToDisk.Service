using Service.Models.Contexts;

namespace Service.API.Endpoints
{
    public class Documents
    {
        /// <summary>
        /// Maps all the API endpoints.
        /// </summary>
        /// <param name="app"></param>
        public static void Endpoints(WebApplication app)
        {
            GetDocuments(app);
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

                return Results.Ok(documents);
            })
            .WithTags("Documents");
        }
    }
}
