namespace api.DAL;

    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base(options) { }
        public DbSet<Class_Course> Courses { get; set; }
        public DbSet<Class_Document> Documents { get; set; }
        public DbSet<Class_Epa> Epaas { get; set; }
        public DbSet<Class_Presentation> Presentations { get; set; }
        public DbSet<Class_Publication> Publications { get; set; }
        public DbSet<Class_Registration> Registration { get; set; }
      
        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            

        }
    }

