using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class ForceAcceptAll : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}

public class APIHelper
{
    public delegate void MyDelegate(string data_str);

    public static IEnumerator PostLicenseInfo(LicenseModel licenseModel , MyDelegate callback)
    {
        string json_data = JsonConvert.SerializeObject(licenseModel);

        using (UnityWebRequest webRequest = UnityWebRequest.Post($"http://localhost:5000/Referral" , json_data))
        {
            webRequest.certificateHandler = new ForceAcceptAll();

            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();           

            switch (webRequest.result)
            { 
                case UnityWebRequest.Result.Success:
                    callback.Invoke(webRequest.downloadHandler.text);
                    break;
                default :
                  callback.Invoke(webRequest.error);
                  break;
            }
        }
    }

}
