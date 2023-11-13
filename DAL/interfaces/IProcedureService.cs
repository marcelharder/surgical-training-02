namespace api.DAL.interfaces;

    public interface IProcedureService
    {
        public Task<List<Class_Procedure>> GetProcedures(int surgeonId, int hospitalId);
        public Task<Class_Procedure> getSpecificProcedure(int id);
       
    }
