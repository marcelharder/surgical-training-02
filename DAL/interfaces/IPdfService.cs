namespace api.DAL.Interfaces;
public interface IPdfService
{
    Task<List<Class_Document>> getFiles(int id);
    Task<Class_Document> getSpecificFile(string id);
    Task<bool> SaveAll();
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;


}