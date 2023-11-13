namespace api.DAL.dtos;

    public class EpaDetailsDto
    {
    public int EpaId {get; set;}
    public string Name {get; set;}
    public string Category {get; set;}
    public int Year {get; set;}
    public DateTime Created {get; set;}
    public string Image {get; set;}
    public int Id { get; set; }
    public int UserId {get; set;}
    public DateTime Date_started {get; set;}
    public DateTime Date_finished {get; set;}
    public Boolean Finished {get; set;}
    public string Grade {get; set;}
    public bool KBP {get; set;}
    public bool OSATS {get; set;}
    public bool Beoordeling_360 {get; set;}
    public bool CAT_CAL {get; set;}
    public bool Examen {get; set;}
    public string Option_6 {get; set;}
    public string Option_7 {get; set;} 
    }
