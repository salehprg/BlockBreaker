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
    static string baseURL = "https://localhost:5001";

    public delegate void MyDelegate(LicenseModel licenseModel ,bool success , string meesage);
    public delegate void ScoreDelegate(ScoreModel scoreModel ,bool success);
    public delegate void HighScoreDelegate(List<ScoreModel> scoreModels ,bool success);

    public static IEnumerator PostLicenseInfo(LicenseModel licenseModel , MyDelegate callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("referralCode", licenseModel.referralCode);
        form.AddField("guid", licenseModel.guid);

        if(licenseModel.nickname != null)
            form.AddField("nickname", licenseModel.nickname);

        if(licenseModel.securityStamp != null)
            form.AddField("securityStamp", licenseModel.securityStamp);

        using (UnityWebRequest webRequest = UnityWebRequest.Post($"{baseURL}/Referral" , form))
        {
            webRequest.certificateHandler = new ForceAcceptAll();

            yield return webRequest.SendWebRequest();           

            switch (webRequest.result)
            { 
                case UnityWebRequest.Result.Success:
                    callback.Invoke(licenseModel , true , webRequest.downloadHandler.text);
                    break;
                default :
                  callback.Invoke(licenseModel , false , webRequest.downloadHandler.text);
                  break;
            }
        }
    }

    public static IEnumerator SubmitScore(ScoreModel scoreModel , ScoreDelegate callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("phone_guid", scoreModel.phone_guid);
        form.AddField("score", scoreModel.score.ToString());

        using (UnityWebRequest webRequest = UnityWebRequest.Post($"{baseURL}/Score" , form))
        {
            webRequest.certificateHandler = new ForceAcceptAll();

            yield return webRequest.SendWebRequest();           

            switch (webRequest.result)
            { 
                case UnityWebRequest.Result.Success:
                    callback.Invoke(scoreModel , true);
                    break;
                default :
                  callback.Invoke(scoreModel , false);
                  break;
            }
        }
    }

    public static IEnumerator HighScores(string guid , HighScoreDelegate callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get($"{baseURL}/Score?guid={guid}"))
        {
            webRequest.certificateHandler = new ForceAcceptAll();

            yield return webRequest.SendWebRequest();           

            switch (webRequest.result)
            { 
                case UnityWebRequest.Result.Success:
                    string jsondata = webRequest.downloadHandler.text;
                    List<ScoreModel> scoreModels = JsonConvert.DeserializeObject<List<ScoreModel>>(jsondata);

                    callback.Invoke(scoreModels , true);
                    break;
                default :
                  callback.Invoke(null , false);
                  break;
            }
        }
    }

}
