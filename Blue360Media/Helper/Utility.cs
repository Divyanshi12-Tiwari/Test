using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace Blue360Media.Helper
{
    public class Utility
    {
        private static readonly string sKey = "UJYHCX783her*&5@$%#(MJCX**38n*#6835ncv56tvbry(&#MX98cn342cn4*&X#&";
        public static string MD5Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return plainText;
            }
            return (EncryptString(plainText, sKey));
        }

        public static string MD5Decrypt(string sEncryptText)
        {
            sEncryptText = sEncryptText.Replace(" ", "+");
            if (string.IsNullOrEmpty(sEncryptText))
            {
                return sEncryptText;
            }
            return (DecryptString(sEncryptText, sKey));
        }
        public static string HTMLToText(string HTMLCode)
        {
            // Remove new lines since they are not visible in HTML
            HTMLCode = HTMLCode.Replace("\n", " ");
            // Remove tab spaces
            HTMLCode = HTMLCode.Replace("\t", " ");
            // Remove multiple white spaces from HTML
            HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");
            // Remove HEAD tag
            HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                , RegexOptions.IgnoreCase | RegexOptions.Singleline);
            // Remove any JavaScript
            HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
              , RegexOptions.IgnoreCase | RegexOptions.Singleline);
            // Replace special characters like &, <, >, " etc.
            StringBuilder sbHTML = new StringBuilder(HTMLCode);
            // Note: There are many more special characters, these are just
            // most common. You can add new characters in this arrays if needed
            string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;",
    "&gt;", "&reg;", "&copy;", "&bull;", "&trade;","&#39;"};
            string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢", "\'" };
            for (int i = 0; i < OldWords.Length; i++)
            {
                sbHTML.Replace(OldWords[i], NewWords[i]);
            }
            // Check if there are line breaks (<br>) or paragraph (<p>)
            sbHTML.Replace("<br>", "\n<br>");
            sbHTML.Replace("<br ", "\n<br ");
            sbHTML.Replace("<p ", "\n<p ");
            // Finally, remove all HTML tags and return plain text
            return System.Text.RegularExpressions.Regex.Replace(
              sbHTML.ToString(), "<[^>]*>", "");
        }
        protected static string EncryptString(string realText, string secretKey)
        {
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(realText);
                byte[] Salt = Encoding.ASCII.GetBytes(secretKey.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(secretKey, Salt);
                ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainText, 0, PlainText.Length);
                cryptoStream.FlushFinalBlock();
                byte[] CipherBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string EncryptedData = Convert.ToBase64String(CipherBytes);
                return EncryptedData;
            }

            catch (Exception exception)
            {
                return (exception.Message);
            }
        }

        protected static string DecryptString(string sEncryptedText, string secretKey)
        {
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] EncryptedData = Convert.FromBase64String(sEncryptedText);
                byte[] Salt = Encoding.ASCII.GetBytes(secretKey.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(secretKey, Salt);
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();
                string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
                return DecryptedData;
            }
            catch (Exception exception)
            {
                return (exception.Message);
            }
        }
    }
}
