using Newtonsoft.Json;

namespace DesignPattern.Model.JWT
{
    public class JWTModel
    {
    }

    public class JWTHeader
    {
        [JsonProperty("alg")]
        public string Algorithm { get; set; }

        [JsonProperty("typ")]
        public string Typ { get; set; }
    }

    public class JWTBodyContent
    {
        [JsonProperty("iat")]
        public string IssuedAt { get; set; }

        [JsonProperty("exp")]
        public long Expire { get; set; }

        [JsonProperty("iss")]
        public string Issuer { get; set; }
    }
}

