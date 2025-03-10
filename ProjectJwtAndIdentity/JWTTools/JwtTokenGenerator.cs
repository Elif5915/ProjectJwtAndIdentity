using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using ProjectJwtAndIdentity.Models;
using System.Security.Claims;
using System.Text;

namespace ProjectJwtAndIdentity.JWTTools;

public class JwtTokenGenerator
{
    //static bir method yapmamız sebebi sınıftan nesne üretimi vs yapmaya gerek duymadan her yerden direkt erişim sağlansın diye static yapıyoruz.
    public static TokenResponseModel GenerateToken(ResultAppUser resultAppUser)
    {
        // claims oluşturma; istemcimiz 
        var claims = new List<Claim>(); //token içinde olacak verileri tutar

        // istemcimizin içine dışarıdan/modelimzden gelenlerden istediklerini claim içine ekleme yapıyoruz.
        // Yani tokenın içine ne göndermek istiyorsak onları ekliyoruz. aslında token içine bilgileri yükleme yapılıyor.
        claims.Add(new Claim(ClaimTypes.Name, resultAppUser.Name));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, resultAppUser.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Surname, resultAppUser.SurName));
        claims.Add(new Claim(ClaimTypes.Email, resultAppUser.Email));
        claims.Add(new Claim("UserName", resultAppUser.UserName));
        claims.Add(new Claim("City", resultAppUser.City));

        //token oluşturma kodları
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
        var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        return null;

    }
}
