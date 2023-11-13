namespace api.DAL.implementations;

    public class DapperCourseService : IDapperCourseService
    {

        private readonly DapperContext _context;

        public DapperCourseService(DapperContext context)
        {
            _context = context;
        }

        public async Task<Class_Course> CreateCourse(CourseDetailsDto up)
        {
            var query = "INSERT INTO Courses" +
                       "(CourseId,description,dateAdded,userId,active,level,CME_hours,Organizer,title,diploma,venue_location,courseDate,endDate,price)" +
                       "VALUES (@CourseId,@description,@dateAdded,@userId,@active,@level,@CME_hours,@Organizer,@title,@diploma,@venue_location,@courseDate,@endDate,@price) returning CourseId";

            var parameters = new DynamicParameters();
            parameters.Add("CourseId", up.CourseId, System.Data.DbType.Int32);
            parameters.Add("description", up.description, System.Data.DbType.String);
            parameters.Add("dateAdded", up.dateAdded, System.Data.DbType.Date);
            parameters.Add("userId", up.userId, System.Data.DbType.Int32);
            parameters.Add("active", up.active, System.Data.DbType.Boolean);
            parameters.Add("level", up.level, System.Data.DbType.Int32);
            parameters.Add("CME_hours", up.CME_hours, System.Data.DbType.Decimal);
            parameters.Add("Organizer", up.Organizer, System.Data.DbType.String);
            parameters.Add("title", up.title, System.Data.DbType.String);
            parameters.Add("diploma", up.diploma, System.Data.DbType.String);
            parameters.Add("venue_location", up.venue_location, System.Data.DbType.String);
            parameters.Add("courseDate", up.courseDate, System.Data.DbType.Date);
            parameters.Add("endDate", up.endDate, System.Data.DbType.Date);
            parameters.Add("price", up.price, System.Data.DbType.Decimal);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdDocument = new Class_Course
                {
                    CourseId = id,
                    Description = up.description,
                    DateAdded = up.dateAdded,
                    UserId = up.userId,
                    Active = up.active,
                    Level = up.level,
                    CME_hours = up.CME_hours,
                    Organizer = up.Organizer,
                    Title = up.title,
                    Diploma = up.diploma,
                    Venue_location = up.venue_location,
                    CourseDate = up.courseDate,
                    EndDate = up.endDate,
                    Price = up.price
                };
                return createdDocument;

            }
        }

        public async Task DeleteCourse(int Id)
        {
            var query = "DELETE FROM Courses WHERE CourseId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id });
            }
        }

        public async Task<List<Class_Course>> GetCourses(int userId)
        {
            var query = "Select * FROM Courses WHERE userId = @userId";
            using (var connection = _context.CreateConnection())
            {
                var documents = await connection.QueryAsync<Class_Course>(query, new { userId });
                return documents.ToList();
            }
        }

        public async Task<Class_Course> getSpecificCourse(int id)
        {
            var query = "Select * FROM Courses WHERE CourseId = @id";
            using (var connection = _context.CreateConnection())
            {
                var document = await connection.QueryFirstOrDefaultAsync<Class_Course>(query, new { id });
                return document;
            }
        }

        public async Task UpdateCourse(CourseDetailsDto up)
        {
            var query = "UPDATE Courses SET description = @description," +
            "dateAdded = @dateAdded, active = @active, level = @level, CME_hours = @CME_hours," +
            "Organizer = @Organizer, title = @title, diploma = @diploma, venue_location = @venue_location," +
            "courseDate = @courseDate, endDate = @endDate, price = @price," +
            "userId = @userId WHERE CourseId = @CourseId";

            var parameters = new DynamicParameters();
            parameters.Add("CourseId", up.CourseId, System.Data.DbType.Int32);
            parameters.Add("description", up.description, System.Data.DbType.String);
            parameters.Add("dateAdded", up.dateAdded, System.Data.DbType.Date);
            parameters.Add("userId", up.userId, System.Data.DbType.Int32);
            parameters.Add("active", up.active, System.Data.DbType.Boolean);
            parameters.Add("level", up.level, System.Data.DbType.Int32);
            parameters.Add("CME_hours", up.CME_hours, System.Data.DbType.Decimal);
            parameters.Add("Organizer", up.Organizer, System.Data.DbType.String);
            parameters.Add("title", up.title, System.Data.DbType.String);
            parameters.Add("diploma", up.diploma, System.Data.DbType.String);
            parameters.Add("venue_location", up.venue_location, System.Data.DbType.String);
            parameters.Add("courseDate", up.courseDate, System.Data.DbType.Date);
            parameters.Add("endDate", up.endDate, System.Data.DbType.Date);
            parameters.Add("price", up.price, System.Data.DbType.Decimal);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
