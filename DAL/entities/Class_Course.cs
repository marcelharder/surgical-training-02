

namespace api.DAL.entities;
 public class Class_Course
    {

        [Key]
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int Level { get; set; }
        public float CME_hours { get; set; }
        public string Organizer { get; set; }
        public string Title { get; set; }
        public string Diploma { get; set; }
        public string Venue_location { get; set; }
        public DateTime CourseDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set; }

        public Class_Course()
        {
            DateAdded = DateTime.Now;
        }

    }