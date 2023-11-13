namespace api.DAL.implementations;

    public class ProcedureService : IProcedureService
    {

        private readonly DapperContext _context;
        public ProcedureService(DapperContext context)
        {
            _context = context;
        }


        
        public async Task<List<Class_Procedure>> GetProcedures(int surgeonId, int hospitalId)
        {
            var query = "Select * FROM soa.Procedures WHERE selectedSurgeon = @surgeonId AND hospital = @hospitalId";
            using (var connection = _context.CreateConnection())
            {
                var documents = await connection.QueryAsync<Class_Procedure>(query, new { surgeonId, hospitalId });
                return documents.ToList();
            }
        }

        public async Task<Class_Procedure> getSpecificProcedure(int id)
        {
            var query = "Select * FROM soa.Procedures WHERE ProcedureId = @id";
            using (var connection = _context.CreateConnection())
            {
                var document = await connection.QueryFirstOrDefaultAsync<Class_Procedure>(query, new { id });
                return document;
            }
        }

     
    }

