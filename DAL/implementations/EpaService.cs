namespace api.DAL.implementations;

public class EpaService : IEpaService
{
    private readonly dataContext _context;
    private DapperContext _dapContext;
    private SpecialMaps _spec;


    public EpaService(dataContext context, SpecialMaps spec, DapperContext dapContext)
    {
        _context = context;
        _spec = spec;
        _dapContext = dapContext;
    }
   

    public async Task<Class_Epa> getIndividualEpa_Dapper(int id)
    {
        var query = "Select * FROM Epaas WHERE EpaID = @id";
        using (var connection = _dapContext.CreateConnection())
        {
            var selectedEpa = await connection.QueryFirstOrDefaultAsync<Class_Epa>(query, new { id });
            if (selectedEpa != null) { return selectedEpa; }
            return null;
        }
    }
    public async Task<List<EpaDetailsDto>> getList_Dapper(int userid)
    {
        var l = new List<Class_Epa>();
        var lr = new List<EpaDetailsDto>();

        // see if there is a epa for this userId, if not than add 15 epa's

        var query = "Select * FROM Epaas WHERE userId = @userid";
        using (var connection = _dapContext.CreateConnection())
        {
            var epapresent = await connection.QueryAsync<Class_Epa>(query, new { userid });
            if (epapresent.ToList().Count() == 0) { await postEpa_Dapper(userid); } // add 15 records for this user

            await Task.Run(() => { l = _context.Epaas.Where(x => x.userId == userid).ToList(); });

            foreach (Class_Epa eps in l)
            {
                lr.Add(_spec.MapToEpaDetailsDto(eps));
            }
            return lr;
        }
    }
    public async Task<List<EpaDetailsDto>> postEpa_Dapper(int cuid)
    {
        var result = new List<EpaDetailsDto>();
        // make a list of 15 epa's
        for (int x = 1; x < 16; x++)
        {
            var help = await addEpaDapperAsync(cuid, x);
            result.Add(help);
        }
        return result;
    }
    private async Task<EpaDetailsDto> addEpaDapperAsync(int cuid, int x)
    {
        var query = "INSERT INTO Epaas" +
         "(EpaID,Name,Category,Year,Finished,Created,Image,Date_started,Date_finished,Grade,KBP,OSATS,Beoordeling_360,CAT_CAL,Examen,Option_6,Option_7,userId)" +
         "VALUES " +
         "(@EpaID,@Name,@Category,@Year,@Finished,@Created,@Image,@Date_started,@Date_finished,@Grade,@KBP,@OSATS,@Beoordeling_360,@CAT_CAL,@Examen,@Option_6,@Option_7,@userId)" +
         " returning Id";
        var parameters = new DynamicParameters();
        parameters.Add("EpaID", x, System.Data.DbType.Int32);
        parameters.Add("userId", cuid, System.Data.DbType.Int32);
        parameters.Add("Name", "", System.Data.DbType.String);
        parameters.Add("Category", "", System.Data.DbType.String);
        parameters.Add("Year", 0, System.Data.DbType.Int32);
        parameters.Add("Finished", false, System.Data.DbType.Boolean);
        parameters.Add("Created", "01-01-0001 00:00:00", System.Data.DbType.Date);
        parameters.Add("Image", "", System.Data.DbType.String);
        parameters.Add("Date_started", "01-01-0001 00:00:00", System.Data.DbType.Date);
        parameters.Add("Date_finished", "01-01-0001 00:00:00", System.Data.DbType.Date);
        parameters.Add("Grade", "", System.Data.DbType.String);
        parameters.Add("KBP", false, System.Data.DbType.Boolean);
        parameters.Add("OSATS", false, System.Data.DbType.Boolean);
        parameters.Add("Beoordeling_360", false, System.Data.DbType.Boolean);
        parameters.Add("CAT_CAL", false, System.Data.DbType.Boolean);
        parameters.Add("Examen", false, System.Data.DbType.Boolean);
        parameters.Add("Option_6", "", System.Data.DbType.String);
        parameters.Add("Option_7", "", System.Data.DbType.String);

        using (var connection = _dapContext.CreateConnection())
        {
            var id = await connection.QuerySingleAsync<int>(query, parameters);
            var createdDocument = new Class_Epa
            {
                EpaID = id,
                userId = cuid,
                Finished = false,
                KBP = false,
                Beoordeling_360 = false,
                CAT_CAL = false,
                Examen = false,
                OSATS = false
            };
            return _spec.MapToEpaDetailsDto(createdDocument);

        }





    }
    public async Task updateDapperEpa(EpaDetailsDto up)
        {
            var query = "UPDATE Epaas SET EpaId = @EpaId," +
            "Name = @name, Category = @category,Year = @year,Created = @created, Image = @image," +
            "Date_started = @date_started,Date_finished = @date_finished,Finished = @finished,Grade = @grade, KBP = @KBP," +
            "OSATS = @OSATS, Beoordeling_360 = @Beoordeling_360,CAT_CAL = @CAT_CAL,Examen = @Examen, Option_6 = @option_6,Option_7 = @option_7 " +
            "WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("EpaId", up.EpaId, System.Data.DbType.Int32);
            parameters.Add("Id", up.Id, System.Data.DbType.Int32);
            parameters.Add("name", up.Name, System.Data.DbType.String);
            parameters.Add("category", up.Category, System.Data.DbType.String);
            parameters.Add("year", up.Year, System.Data.DbType.Int32);
            parameters.Add("created", up.Created, System.Data.DbType.Date);
            parameters.Add("image", up.Image, System.Data.DbType.String);
            parameters.Add("date_started", up.Date_started, System.Data.DbType.Date);
            parameters.Add("date_finished", up.Date_finished, System.Data.DbType.Date);
            parameters.Add("finished", up.Finished, System.Data.DbType.Boolean);
            parameters.Add("grade", up.Grade, System.Data.DbType.String);
            parameters.Add("KBP", up.KBP, System.Data.DbType.Boolean);
            parameters.Add("OSATS", up.OSATS, System.Data.DbType.Boolean);
            parameters.Add("Beoordeling_360", up.Beoordeling_360, System.Data.DbType.Boolean);
            parameters.Add("CAT_CAL", up.CAT_CAL, System.Data.DbType.Boolean);
            parameters.Add("Examen", up.Examen, System.Data.DbType.Boolean);
            parameters.Add("option_6", up.Option_6, System.Data.DbType.String);
            parameters.Add("option_7", up.Option_7, System.Data.DbType.Int32);
            using (var connection = _dapContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
          }
    public async Task deleteDapperEpaAsync(int id)
    {
        var query = "DELETE FROM Epaas WHERE Id = @id";
        using (var connection = _dapContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { id });
        }
        
    }

    
}
