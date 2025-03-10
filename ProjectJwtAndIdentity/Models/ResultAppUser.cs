namespace ProjectJwtAndIdentity.Models;

public class ResultAppUser
{
    //kullanıcıların bilgilerini tutacağımız modelimiz
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
}
