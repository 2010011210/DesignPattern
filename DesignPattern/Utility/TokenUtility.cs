using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using DesignPattern.Model.JWT;
using System.Security.Cryptography;
using System.Text.Unicode;
using Org.BouncyCastle.Utilities.Encoders;

namespace DesignPattern.Utility
{
    public class TokenUtility
    {
        public static string GetToken(string appid, string secret) 
        {
            // 1.组装Claim
            var issuedAtTimestamp = DateTimeExtension.GetUnixTimeStamp(DateTime.Now);
            var claims = new Claim[]
            {
                new Claim("iat", issuedAtTimestamp.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));  // 密码要从配置文件中读取，或者从数据库读取
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3.
            /**
             * Claims (Payload)
                Claims 部分包含了一些跟这个 token 有关的重要信息。 JWT 标准规定了一些字段，下面节选一些字段:
                iss: The issuer of the token，token 是给谁的
                sub: The subject of the token，token 主题
                exp: Expiration Time。 token 过期时间，Unix 时间戳格式
                iat: Issued At。 token 创建时间， Unix 时间戳格式
                jti: JWT ID。针对当前 token 的唯一标识
                除了规定的字段外，可以包含其他任何 JSON 兼容的字段。
             * */
            var token = new JwtSecurityToken(
                issuer: appid,
                claims: claims,
                expires: DateTime.Now.AddSeconds(60 * 60),//10分钟有效期
                //notBefore: DateTime.Now,//立即生效  DateTime.Now.AddMilliseconds(30),//30s后有效
                signingCredentials: creds);

            //var iat = token.Payload.IssuedAt;
            string returnToken = new JwtSecurityTokenHandler().WriteToken(token);
            return returnToken;
        }

        public static string GetJWT(string appId, string secret) 
        {
            var jwtHeader = new JWTHeader() 
            {
                Algorithm = "HS256",
                Typ = "JWT"
            };

            var jwtBody = new JWTBodyContent()
            {
                IssuedAt = DateTimeExtension.GetUnixTimeStamp(DateTime.Now).ToString(),
                Issuer = appId,
                Expire = DateTimeExtension.GetUnixTimeStamp(DateTime.Now.AddSeconds(60*60)),
            };

            var jwtFullContent = $"{Security.ConvertToBase64(Newtonsoft.Json.JsonConvert.SerializeObject(jwtHeader))}.{Security.ConvertToBase64(Newtonsoft.Json.JsonConvert.SerializeObject(jwtBody))}";
            var contentBytes = Security.HmacSha256(secret,jwtFullContent);
            var jwtPlain = BitConverter.ToString(contentBytes);
            var jwtPlain2 = System.Text.Encoding.UTF8.GetString(contentBytes);
            var base64String = Base64.ToBase64String(contentBytes, 0, contentBytes.Length);
            var jwt3 = Security.HmacSha256String(secret, jwtFullContent);

            var base64UrlEncoderString = Security.Base64UrlEncoderEncode(contentBytes, 0, contentBytes.Length);
            var fullJWT = $"{jwtFullContent}.{base64String}";
            Console.WriteLine($"生成的JWT：{fullJWT}");
            return fullJWT;
        
        }
    }
}
