namespace api.DAL.implementations;

public class PresentationService : IPresentationService
{
    private readonly DapperContext _context;
    public PresentationService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Class_Presentation> CreatePresentation(PresentationDetailsDto pdf)
    {
       var query = "INSERT INTO Presentations" +
        "(Title,Media,Venue,DatePresented,UserId)" +
        "VALUES (@title, @media, @venue, @datePresented,@userId) returning PresentationId";
        var parameters = new DynamicParameters();
        parameters.Add("title", pdf.Title, System.Data.DbType.String);
        parameters.Add("media", pdf.Media, System.Data.DbType.String);
        parameters.Add("venue", pdf.Venue, System.Data.DbType.String);
        parameters.Add("datePresented", pdf.DatePresented, System.Data.DbType.Date);
        parameters.Add("userId", pdf.UserId, System.Data.DbType.Int32);


        using var connection = _context.CreateConnection();
        var id = await connection.QuerySingleAsync<int>(query, parameters);
        var createdDocument = new Class_Presentation
        {
            PresentationId = id,
            Title = pdf.Title,
            Media = pdf.Media,
            Venue = pdf.Venue,
            UserId = pdf.UserId,
            DatePresented = pdf.DatePresented,

        };
        return createdDocument;
    }

    public async Task DeletePresentation(int id)
    {
        var query = "DELETE FROM Presentations WHERE PresentationId = @id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
    }

    public async Task<List<Class_Presentation>> GetPresentations(int userId)
    {
       var query = "Select * FROM Presentations WHERE UserId = @userId";
            using (var connection = _context.CreateConnection())
            {
                var documents = await connection.QueryAsync<Class_Presentation>(query, new { userId });
                return documents.ToList();
            }
    }

    public async Task UpdatePresentation(PresentationDetailsDto up)
    {
         var query = "UPDATE Presentations SET Title = @title, " +
            "Media = @media, Venue = @venue, DatePresented = @datePresented " +
            "WHERE PresentationId = @PresentationId";

            var parameters = new DynamicParameters();
            parameters.Add("PresentationId", up.PresentationId, System.Data.DbType.Int32);
            parameters.Add("title", up.Title, System.Data.DbType.String);
            parameters.Add("media", up.Media, System.Data.DbType.String);
            parameters.Add("venue", up.Venue, System.Data.DbType.String);
            parameters.Add("datePresented", up.DatePresented, System.Data.DbType.Date);
          

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
    }

    public async Task<Class_Presentation> getSpecificPresentation(int id)
    {
          var query = "Select * FROM Presentations WHERE PresentationId = @id";
            using (var connection = _context.CreateConnection())
            {
                var document = await connection.QueryFirstOrDefaultAsync<Class_Presentation>(query, new { id });
                return document;
            }
    }
}