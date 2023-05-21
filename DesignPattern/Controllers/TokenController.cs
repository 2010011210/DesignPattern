using DesignPattern.Utility;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Utilities.Encoders;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace DesignPattern.Controllers
{
    /// <summary>
    /// 创建型
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        [HttpPost]
        [Route("GetToken")]
        public string GetToken([FromForm] string appId, [FromForm]  string secret)
        {
            appId = "CrY8lwdVTdFro9ZMRTsp5fshXOQOesu3";
            secret = "S15zjZTwzrnvGrthxMyEwXf3Ri43ErK5";
            string returnToken = TokenUtility.GetToken(appId, secret);  //GetJWT
            string jwt = TokenUtility.GetJWT(appId, secret);  //GetJWT
            return returnToken;
        }

        [HttpPost]
        [Route("Decrypt")]
        public string Decrypt()
        {
            string key = "a33c1a63cc7717cb1f31323562bc5361";
            string msg = "9782E1B3CA20D11027BC5F3FED5FCA023625AAAF380EEE9BE8D0C0A559AF9771A6B4329DBBA1D6D2873222CAF9D049020C4BEED45452F2B9A5CBADC40E0E9A75D0FA8D08394165AED75C2C7B80586FC5349798C74D0B8822FE155A84FDD7CB423AD142A3E30BB0B87446A7C2C57D095DD0AE30487F2495287EE5B0E604207F84";
            //string base64Msg = "l4Lhs8og0RAnvF8/7V/KAjYlqq84Du6b6NDApVmvl3GmtDKdu6HW0ocyIsr50EkCDEvu1FRS8rmly63EDg6addD6jQg5QWWu11wse4BYb8U0l5jHTQuIIv4VWoT918tCOtFCo+MLsLh0RqfCxX0JXdCuMEh/JJUofuWw5gQgf4Q=";
            string base64Msg = ConvertHexToBase64(msg);
            var result = Security.DecryptAES(base64Msg, key);
            return result; 
        }

        private string ConvertHexToBase64(string msg) 
        {
            //string msg = "9782E1B3CA20D11027BC5F3FED5FCA023625AAAF380EEE9BE8D0C0A559AF9771A6B4329DBBA1D6D2873222CAF9D049020C4BEED45452F2B9A5CBADC40E0E9A75D0FA8D08394165AED75C2C7B80586FC5349798C74D0B8822FE155A84FDD7CB423AD142A3E30BB0B87446A7C2C57D095DD0AE30487F2495287EE5B0E604207F84";

            var result = Hex.Decode(System.Text.Encoding.UTF8.GetBytes(msg));
            return Base64.ToBase64String(result, 0, result.Length);
        }
    }
}
