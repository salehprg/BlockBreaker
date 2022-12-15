using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLicense : MonoBehaviour
{
    
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            print("Checking License");
        }
    }

    
    public void SubmitLicense(TMPro.TMP_InputField input)
    {
        LicenseModel licenseModel = new LicenseModel();
        
        string license = input.text;

        license = RSA.Encrypt(license);

        print(license);
        
        licenseModel.referralCode = license;
        licenseModel.guid = "1234";
        licenseModel.securityStamp = "test";

        APIHelper.MyDelegate del = DelegateMethod;   

        StartCoroutine(APIHelper.PostLicenseInfo(licenseModel , del));

    }

    public void DelegateMethod(string data_str)
    {
        print(data_str);
    }
}
