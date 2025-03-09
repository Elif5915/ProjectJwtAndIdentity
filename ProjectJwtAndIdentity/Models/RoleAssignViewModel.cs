namespace ProjectJwtAndIdentity.Models;

public class RoleAssignViewModel
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool RoleExist { get; set; } //kullanıcı bu role sahip mi değil mi değerini tutacak
}
