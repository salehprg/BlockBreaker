using System;
using System.Security.Cryptography;
using System.Text;

class RSA
{
    public static string Encrypt(string data)
    {
        var publicKey = "MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgEmXDCIZDpNeOpGWyfaQqXhQdCk/"+
                        "vZ6rm2OKHDTEKuYEz6t7GmU4Aj0PH+3AyCPjWZotu5+Ong1GjQ7f4DpMa07ikINQ"+
                        "zzf2UvbPXVaaAaUKGZ2M+VG+iRv+9AGOfWNBScT4PTAz4Ix/hXHf7v7d8Lxj7wJf"+
                        "x6PfObDeRvwzoXHLAgMBAAE=";
      
        using ( var rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                int byteread = 0;

                rsa.ImportRSAPublicKey(Encoding.UTF8.GetBytes(publicKey) , out byteread);
                
                var encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(data), true);
                
                var base64Encrypted = Convert.ToBase64String(encryptedData);
                
                
                return base64Encrypted;
                
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }
}