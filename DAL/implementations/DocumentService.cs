
namespace api.DAL.implementations;

public class DocumentService : IDocumentService
{
    private readonly DapperContext _context;
    private SpecialMaps _spec;
    public DocumentService(DapperContext context, SpecialMaps spec)
    {
        _context = context;
        _spec = spec;

    }

    public async Task<Class_Document> Create(PdfForCreationDto pdf)
    {
        var query = "INSERT INTO Documents" +
        "(description,dateAdded,type,finished,document_url,publicId, userId)" +
        "VALUES (@description, @dateAdded, @type, @finished, @document_url, @publicId, @userId) returning documentId";
        var parameters = new DynamicParameters();
        parameters.Add("description", pdf.Description, System.Data.DbType.String);
        parameters.Add("dateAdded", pdf.DateAdded, System.Data.DbType.Date);
        parameters.Add("type", pdf.Type, System.Data.DbType.Int32);
        parameters.Add("finished", pdf.Finished, System.Data.DbType.Boolean);
        parameters.Add("document_url", pdf.Document_url, System.Data.DbType.String);
        parameters.Add("publicId", pdf.PublicId, System.Data.DbType.String);
        parameters.Add("userId", pdf.UserId, System.Data.DbType.Int32);

        using (var connection = _context.CreateConnection())
        {
            var id = await connection.QuerySingleAsync<int>(query, parameters);
            var createdDocument = new Class_Document
            {
                DocumentId = id,
                Description = pdf.Description,
                DateAdded = pdf.DateAdded,
                Type = pdf.Type,
                Finished = pdf.Finished,
                Document_url = pdf.Document_url,
                PublicId = pdf.PublicId,
                UserId = pdf.UserId
            };
            return createdDocument;
        }
    }


    public async Task<List<Class_Document>> getFiles(int id)
    {
        var query = "Select * FROM Documents WHERE userId = @id";
        using (var connection = _context.CreateConnection())
        {
            var documents = await connection.QueryAsync<Class_Document>(query, new { id });
            return documents.ToList();
        }
    }

    public async Task<Class_Document> getSpecificFile(int id)
    {
        var query = "Select * FROM Documents WHERE documentId = @id";
        using (var connection = _context.CreateConnection())
        {
            var document = await connection.QueryFirstOrDefaultAsync<Class_Document>(query, new { id });
            return document;
        }
    }


    public async Task Update(PdfForCreationDto pdf)
    {
        var query = "UPDATE Documents SET description = @description," +
       "dateAdded = @dateAdded, type = @type,finished = @finished,document_url = @document_url, publicId = @publicId," +
       "userId = @userId WHERE documentId = @documentId";

        var parameters = new DynamicParameters();
        parameters.Add("documentId", pdf.DocumentId, System.Data.DbType.Int32);
        parameters.Add("description", pdf.Description, System.Data.DbType.String);
        parameters.Add("dateAdded", pdf.DateAdded, System.Data.DbType.Date);
        parameters.Add("type", pdf.Type, System.Data.DbType.Int32);
        parameters.Add("finished", pdf.Finished, System.Data.DbType.Boolean);
        parameters.Add("document_url", pdf.Document_url, System.Data.DbType.String);
        parameters.Add("publicId", pdf.PublicId, System.Data.DbType.String);
        parameters.Add("userId", pdf.UserId, System.Data.DbType.Int32);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task Delete(int id)
    {
        var query = "DELETE FROM Documents WHERE documentId = @Id";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { id });
        }
    }

}
