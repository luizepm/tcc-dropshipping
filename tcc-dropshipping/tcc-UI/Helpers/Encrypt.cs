using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace tcc_UI.Helpers
{
    public static class Encrypt
    {
        public static string EncryptValue(string text)
        {
            try
            {
                byte[] encData_byte = new byte[text.Length];

                encData_byte = Encoding.UTF8.GetBytes(text);
                var encodedData = Convert.ToBase64String(encData_byte);

                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string DecryptValue(string text)
        {
            var encoder = new UTF8Encoding();
            var utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(text);

            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

            var decoded_char = new char[charCount];

            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            var result = new string(decoded_char);

            return result;
        }
    }
}