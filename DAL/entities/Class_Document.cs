namespace api.DAL.models;

    public class Class_Document
    {
    [Key]
    public int DocumentId {get; set;}
    public string Description {get; set;}
    public DateTime DateAdded {get; set;}
    public int Type {get; set;}
    public Boolean Finished {get; set;}
    public string Document_url {get; set;}
    public string PublicId {get; set;}
    public int UserId {get; set;} 

    public Class_Document()
    {
         DateAdded = DateTime.Now;
    }
    }
