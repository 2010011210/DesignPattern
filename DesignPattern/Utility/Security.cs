using Microsoft.IdentityModel.Logging;
using Org.BouncyCastle.Utilities.Encoders;
using System.Security.Cryptography;
using System.Text;

namespace DesignPattern.Utility
{
    public class Security
    {
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="str">需要解密的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="mode">模式</param>
        /// <param name="encoding">编码</param>
        /// <param name="IVLength">偏移量</param>
        /// <returns>解密后的字符串</returns>
        public static string DecryptAES(string str, string key, CipherMode mode = CipherMode.ECB, string encoding = "UTF-8", int? IVLength = null)
        {
            byte[] keyArray = Encoding.GetEncoding(encoding).GetBytes(key); //Convert.FromBase64String(key);// 
            byte[] toDecryptArray = Convert.FromBase64String(str);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            if (IVLength != null)
            {
                rDel.IV = Encoding.ASCII.GetBytes(key.Substring(0, IVLength.Value));
            }
            rDel.Mode = mode;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

            return Encoding.GetEncoding(encoding).GetString(resultArray);
        }

        public static byte[] HmacSha256(byte[] key, string data) 
        {
            var hashAlgorithm = new HMACSHA256(key);

            return hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static byte[] HmacSha256(string key, string data)
        {
            var hashAlgorithm = new HMACSHA256(Encoding.UTF8.GetBytes(key));

            return hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        public static string ConvertToBase64(string msg)
        {
            var result = System.Text.Encoding.UTF8.GetBytes(msg);
            return Base64.ToBase64String(result, 0, result.Length);
        }

        public static string HmacSha256String(string password, string str) 
        {
            var encoding = Encoding.UTF8;

            byte[] keyByte = encoding.GetBytes(password);
            byte[] parametersByte = encoding.GetBytes(str);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(parametersByte);
                StringBuilder result = new StringBuilder();
                var format = "X2";
                for (int i = 0; i < hashmessage.Length; i++)
                {
                    result.Append(hashmessage[i].ToString(format));
                }
                return result.ToString();
            }
            return "";
        }

        internal static readonly char[] s_base64Table = new char[64]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
            'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '-', '_'
        };

        public static string Base64UrlEncoderEncode(byte[] inArray, int offset, int length)
        {
            if (inArray == null)
            {
                throw LogHelper.LogArgumentNullException("inArray");
            }

            if (offset < 0)
            {
                throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException(LogHelper.FormatInvariant("IDX10716: '{0}' must be greater than 0, was: '{1}'", LogHelper.MarkAsNonPII("offset"), LogHelper.MarkAsNonPII(offset))));
            }

            if (length == 0)
            {
                return string.Empty;
            }

            if (length < 0)
            {
                throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException(LogHelper.FormatInvariant("IDX10716: '{0}' must be greater than 0, was: '{1}'", LogHelper.MarkAsNonPII("length"), LogHelper.MarkAsNonPII(length))));
            }

            if (inArray.Length < offset + length)
            {
                throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException(LogHelper.FormatInvariant("IDX10717: '{0} + {1}' must not be greater than {2}, '{3} + {4} > {5}'.", LogHelper.MarkAsNonPII("offset"), LogHelper.MarkAsNonPII("length"), LogHelper.MarkAsNonPII("inArray"), LogHelper.MarkAsNonPII(offset), LogHelper.MarkAsNonPII(length), LogHelper.MarkAsNonPII(inArray.Length))));
            }

            int num = length % 3;
            int num2 = offset + (length - num);
            char[] array = new char[(length + 2) / 3 * 4];
            char[] array2 = s_base64Table;
            int num3 = 0;
            int i;
            for (i = offset; i < num2; i += 3)
            {
                byte b = inArray[i];
                byte b2 = inArray[i + 1];
                byte b3 = inArray[i + 2];
                array[num3] = array2[b >> 2];
                array[num3 + 1] = array2[((b & 3) << 4) | (b2 >> 4)];
                array[num3 + 2] = array2[((b2 & 0xF) << 2) | (b3 >> 6)];
                array[num3 + 3] = array2[b3 & 0x3F];
                num3 += 4;
            }

            i = num2;
            switch (num)
            {
                case 2:
                    {
                        byte b5 = inArray[i];
                        byte b6 = inArray[i + 1];
                        array[num3] = array2[b5 >> 2];
                        array[num3 + 1] = array2[((b5 & 3) << 4) | (b6 >> 4)];
                        array[num3 + 2] = array2[(b6 & 0xF) << 2];
                        num3 += 3;
                        break;
                    }
                case 1:
                    {
                        byte b4 = inArray[i];
                        array[num3] = array2[b4 >> 2];
                        array[num3 + 1] = array2[(b4 & 3) << 4];
                        num3 += 2;
                        break;
                    }
            }

            return new string(array, 0, num3);
        }

    }
}
