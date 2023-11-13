namespace api.DAL.Interfaces;

    public interface IDocumentService
    {
        Task<List<Class_Document>> getFiles(int id);
        Task<Class_Document> getSpecificFile(int id);
        Task<Class_Document> Create(PdfForCreationDto pdf);
        Task Delete(int id);
        Task Update(PdfForCreationDto pdf);
        
    }
