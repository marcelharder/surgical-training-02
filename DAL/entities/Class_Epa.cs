namespace api.DAL.entities;

    public class Class_Epa
    {
    [Key]
    public int Id {get; set;}
    public int EpaID {get; set;}
    public string Name {get; set;}
    public string Category {get; set;}
    public int Year {get; set;}
    public Boolean Finished {get; set;}
    public DateTime? Created {get; set;}
    public string Image {get; set;}
    public DateTime Date_started {get; set;}
    public DateTime Date_finished {get; set;}
    public string Grade {get; set;}
    public bool KBP {get; set;}
    public bool OSATS {get; set;}
    public bool Beoordeling_360 {get; set;}
    public bool CAT_CAL {get; set;}
    public bool Examen {get; set;}
    public string Option_6 {get; set;}
    public string Option_7 {get; set;} 
    public int userId {get; set;} 

    }

