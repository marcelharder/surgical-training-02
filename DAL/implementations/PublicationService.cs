
namespace api.DAL.implementations;

public class PublicationService : IPublicationService
{
    private readonly DapperContext _context;
    public PublicationService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Class_Publication> CreatePublication(PublicationDetailsDto up)
    {
        var query = "INSERT INTO Publications" +
       "(UserId, Author,Title,Volume,Issue,PlaceOfPublication,publisher,editor,url,doi,dateOfPublication)" +
       "VALUES (@userId, @author, @title, @volume,@issue,@placeOfPublication,@publisher,@editor,@url, @doi, @dateOfPublication) returning PublicationId";

        var parameters = new DynamicParameters();
        parameters.Add("userId", up.UserId, System.Data.DbType.Int32);
        parameters.Add("author", up.Author, System.Data.DbType.String);
        parameters.Add("title", up.Title, System.Data.DbType.String);
        parameters.Add("volume", up.Volume, System.Data.DbType.String);
        parameters.Add("issue", up.Issue, System.Data.DbType.String);
        parameters.Add("placeOfPublication", up.PlaceOfPublication, System.Data.DbType.String);
        parameters.Add("publisher", up.Publisher, System.Data.DbType.String);
        parameters.Add("editor", up.Editor, System.Data.DbType.String);
        parameters.Add("url", up.URL, System.Data.DbType.String);
        parameters.Add("doi", up.DOI, System.Data.DbType.String);
        parameters.Add("dateOfPublication", up.DateOfPublication, System.Data.DbType.Date);

        using var connection = _context.CreateConnection();
        var id = await connection.QuerySingleAsync<int>(query, parameters);
        var createdDocument = new Class_Publication
        {
            PublicationId = id,
            UserId = up.UserId,
            Author = up.Author,
            Title = up.Title,
            Volume = up.Volume,
            Issue = up.Issue,
            PlaceOfPublication = up.PlaceOfPublication,
            Publisher = up.Publisher,
            Editor = up.Editor,
            URL = up.URL,
            DOI = up.DOI,
            DateOfPublication = up.DateOfPublication
        };
        return createdDocument;


    }

    public async Task UpdatePublication(PublicationDetailsDto up)
    {
        var query = "UPDATE Publications SET Author = @author, Title = @title, Volume = @volume, Issue = @issue, PlaceOfPublication = @placeOfPublication, " +
            "Publisher = @publisher, Editor = @editor, URL = @url, DOI = @doi, DateOfPublication = @dateOfPublication  " +
            "WHERE PublicationId = @publicationId";

        var parameters = new DynamicParameters();
        parameters.Add("publicationId", up.PublicationId, System.Data.DbType.Int32);
        parameters.Add("author", up.Author, System.Data.DbType.String);
        parameters.Add("title", up.Title, System.Data.DbType.String);
        parameters.Add("volume", up.Volume, System.Data.DbType.String);
        parameters.Add("issue", up.Issue, System.Data.DbType.String);
        parameters.Add("placeOfPublication", up.PlaceOfPublication, System.Data.DbType.String);
        parameters.Add("publisher", up.Publisher, System.Data.DbType.String);
        parameters.Add("editor", up.Editor, System.Data.DbType.String);
        parameters.Add("url", up.URL, System.Data.DbType.String);
        parameters.Add("doi", up.DOI, System.Data.DbType.String);
        parameters.Add("dateOfPublication", up.DateOfPublication, System.Data.DbType.Date);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }



    public async Task DeletePublication(int id)
    {
        var query = "DELETE FROM Publications WHERE PublicationId = @id";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { id });
        }
    }

    public async Task<List<Class_Publication>> GetPublications(int userId)
    {
        var query = "Select * FROM Publications WHERE UserId = @userId";
        using (var connection = _context.CreateConnection())
        {
            var documents = await connection.QueryAsync<Class_Publication>(query, new { userId });
            return documents.ToList();
        }
    }

    public async Task<Class_Publication> getSpecificPublication(int id)
    {
        var query = "Select * FROM Publications WHERE PublicationId = @id";
        using (var connection = _context.CreateConnection())
        {
            var document = await connection.QueryFirstOrDefaultAsync<Class_Publication>(query, new { id });
            return document;
        }
    }


}