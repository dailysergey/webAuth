using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace webAuth.Models
{
    /// <summary>
    /// Константа ISSUER представляет издателя токена. 
    /// Здесь можно определить любое название. 
    /// AUDIENCE представляет потребителя токена - опять же может быть любая строка, но в данном случае указан адрес текущего приложения.
    /// Константа KEY хранит ключ, который будет применяться для создания токена.
    /// </summary>
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
