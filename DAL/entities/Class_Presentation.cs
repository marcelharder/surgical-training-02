namespace api.DAL.entities;

public class Class_Presentation
{
    [Key]
    public int PresentationId { get; set; }
    public int UserId {get; set;}
    public string Title { get; set; }
    public string Media { get; set; }
    public string Venue { get; set; }
    public DateTime DatePresented { get; set; }





}
