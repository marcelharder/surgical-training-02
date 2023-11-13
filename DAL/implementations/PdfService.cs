namespace api.DAL.implementations;

    public class PdfService : IPdfService
    {
        private readonly IWebHostEnvironment _env;
       
        private dataContext _context;

       

        public PdfService(
            IWebHostEnvironment env, 
            dataContext context 
            )

        {
            _env = env;
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<List<Class_Document>> getFiles(int id)
        {
            var l = new List<Class_Document>();
            await Task.Run(()=>{
             l = _context.Documents.Where(x => x.UserId == id).ToList();
            });
            return l;
        }

        public async Task<Class_Document> getSpecificFile(string id)
        {
            var specificFile = await _context.Documents.FirstOrDefaultAsync(x => x.DocumentId == Convert.ToInt32(id));
             return specificFile;
        }

        public async Task<bool> SaveAll()
        {
             return await _context.SaveChangesAsync() > 0;
        }

    }


