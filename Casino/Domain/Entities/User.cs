namespace Casino.Domain.Entities;

public class User
{
    public int id { get; set; }
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Password {  get; set; }
    public string Username {  get; set; }
    public decimal Budget {  get; set; }
    public DateTime CreatedAt { get; set; }
}
