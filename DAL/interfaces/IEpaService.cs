namespace api.DAL.Interfaces;

public interface IEpaService
{
   Task<List<EpaDetailsDto>> getList_Dapper(int userid);
   Task<List<EpaDetailsDto>> postEpa_Dapper(int cuid);
   Task<Class_Epa> getIndividualEpa_Dapper(int id);
   Task updateDapperEpa(EpaDetailsDto ep);
   Task deleteDapperEpaAsync(int id);




}
