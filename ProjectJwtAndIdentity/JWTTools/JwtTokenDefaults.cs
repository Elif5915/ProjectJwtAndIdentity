namespace ProjectJwtAndIdentity.JWTTools;

public class JwtTokenDefaults
{
    //const sabit anlamı taşır ,valid : doğrulama anlamında, Audience : dinleyiicim

    public const string ValidAudience = "https://localhost"; //yani bu token kim tarafından dinlensin,bu dileyicim localhost tarafından dinlensin dedik.
    public const string ValidIssuer = "https://localhost"; //bu da yayıncı yani tokenı oluşturan kim
    public const string Key = "IdentityJwt.1234567890+-*/Token000"; //bu token için bir tane key verelim, bu key bizim tokenı aslında kendi localimde kendine ait şifresi olacak ve bu keyin uzun olması gerekiyor.
    //Bu key 32 karakterden oluşması gerek. random bir şey yazılabiliyor anlamlı/anlamsız olabilir
    public const int Expire = 5; //Expire ise tokenımın geçerlilik süresi, 5 dk verdik biz
     
}
