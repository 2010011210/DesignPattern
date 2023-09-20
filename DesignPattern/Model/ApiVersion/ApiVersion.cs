using System.ComponentModel.DataAnnotations;

namespace DesignPattern.Model.ApiVersion
{
    /// <summary>
    /// 接口版本号
    /// </summary>
    public enum ApiVersion
    {
        [DisplayAttribute(Name ="V1")]
        V1,

        [DisplayAttribute(Name = "V2")]
        V2
    }
}
