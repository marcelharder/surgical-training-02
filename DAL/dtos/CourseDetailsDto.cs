namespace api.DAL.dtos;

public class CourseDetailsDto
    {
        public int CourseId { get; set; }
        public int userId { get; set; }
        public DateTime dateAdded { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public int level { get; set; }
        public float CME_hours { get; set; }
        public string Organizer { get; set; }
        public string title { get; set; }
        public string diploma { get; set; }
        public string venue_location { get; set; }
        public DateTime courseDate { get; set; }
        public DateTime endDate { get; set; }
        public float price { get; set; }

       
    }
