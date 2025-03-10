using System.Drawing;

namespace ProjectJwtAndIdentity.Models;

public class TokenResponseModel
{
    public TokenResponseModel(string token, DateTime expireDate) //bunları constructor olarak çağırıyoruz çünkü bu sınıf çağrışldığı zaman tanımladığımız iki parametrelere ihtiyacım olacak.Ondan dolayı Dependency ınjection uyguladık.
    {
        Token = token;
        ExpireDate = expireDate;
    }
     
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; } //token için en önemli olan şey bu aslında çünkü token ne zamana kadar geçerli olacağını tutar.

}
