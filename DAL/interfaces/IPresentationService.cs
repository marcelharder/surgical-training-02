namespace api.DAL.interfaces;

public interface IPresentationService
    {
        public Task<List<Class_Presentation>> GetPresentations(int userId);
        public Task<Class_Presentation> getSpecificPresentation(int id);
        public Task UpdatePresentation(PresentationDetailsDto up);
        public Task DeletePresentation(int id);
        public Task<Class_Presentation> CreatePresentation(PresentationDetailsDto up);
    }
