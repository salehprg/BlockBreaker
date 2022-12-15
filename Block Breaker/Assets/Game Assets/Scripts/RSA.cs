using System;
using System.Security.Cryptography;
using System.Text;

class RSA
{
    public static string Encrypt(string data)
    {
        var publicKey = "<RSAKeyValue><Modulus>SZcMIhkOk146kZbJ9pCpeFB0KT+9nqubY4ocNMQq5gTPq3saZTgCPQ8f7cDII+NZmi27n46eDUaNDt/gOkxrTuKQg1DPN/ZS9s9dVpoBpQoZnYz5Ub6JG/70AY59Y0FJxPg9MDPgjH+Fcd/u/t3wvGPvAl/Ho985sN5G/DOhccs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
      
        using ( var rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                rsa.FromXmlString(publicKey);
                
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