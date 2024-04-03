namespace api.DAL.interfaces;

public interface IPublicationService
    {
        public Task<List<Class_Publication>> GetPublications(int userId);
        public Task<Class_Publication> getSpecificPublication(int id);
        public Task UpdatePublication(PublicationDetailsDto up);
        public Task DeletePublication(int id);
        public Task<Class_Publication> CreatePublication(PublicationDetailsDto up);
    }
