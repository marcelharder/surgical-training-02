namespace api.DAL.dtos;

public class UserDto
{
    public string Username { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
    public DateTime PaidTill { get; set; }
}
