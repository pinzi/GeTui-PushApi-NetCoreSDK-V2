using System.Security.Cryptography;
using System.Text;

namespace GeTuiPushApiV2.ServerSDK.Core.Utility
{
    /// <summary>
    /// SHA256加解密
    /// </summary>
    public static class SHA256Helper
    {
        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <returns>密文，摘要算法hash值</returns>
        public static string SHA256Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToHexString(hash).ToLowerInvariant();
            }
        }
        /// <summary>
        /// SHA512加密
        /// </summary>
        /// <param name="input">明文</param>
        /// <returns>密文，摘要算法hash值</returns>
        public static string SHA512Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToHexString(hash).ToLowerInvariant();
            }
        }
    }
}
