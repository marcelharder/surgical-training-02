namespace api.DAL.interfaces;

public interface IDapperCourseService
    {
        public Task<List<Class_Course>> GetCourses(int userId);
        public Task<Class_Course> getSpecificCourse(int id);
        public Task UpdateCourse(CourseDetailsDto up);
        public Task DeleteCourse(int id);
        public Task<Class_Course> CreateCourse(CourseDetailsDto up);
    }
