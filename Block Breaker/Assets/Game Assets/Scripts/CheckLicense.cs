using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLicense : MonoBehaviour
{
    public bool LicenseValid = false;
    public Canvas UI;
    public GameObject game;


    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            game.SetActive(false);
            UI.gameObject.SetActive(false);

            print("Checking License");
            
            string license = PlayerPrefs.GetString("code");
            string guid = PlayerPrefs.GetString("guid");

            if(string.IsNullOrEmpty(license))
            {
                try
                {
                    SceneManager.LoadScene("Login");
                }
                catch
                {
                    Application.Quit();
                }
            }

            LicenseModel licenseModel = new LicenseModel();
        
            licenseModel.referralCode = license;
            licenseModel.guid = guid;

            APIHelper.MyDelegate del = OnCheckLicense;   

            StartCoroutine(APIHelper.PostLicenseInfo(licenseModel , del));
        
        }

        if(SceneManager.GetActiveScene().name == "Login")
        {
            print("Checking License");
            
            string license = PlayerPrefs.GetString("code");
            string guid = PlayerPrefs.GetString("guid");

            if(!string.IsNullOrEmpty(license))
            {
                LicenseModel licenseModel = new LicenseModel();
        
                licenseModel.referralCode = license;
                licenseModel.guid = guid;

                APIHelper.MyDelegate del = OnCheckLicense;   

                StartCoroutine(APIHelper.PostLicenseInfo(licenseModel , del));
            }
        }
    }

    
    public void SubmitLicense(TMPro.TMP_InputField input)
    {
        LicenseModel licenseModel = new LicenseModel();
        
        string license = input.text;

        licenseModel.referralCode = RSA.Encrypt(license);
        licenseModel.guid = System.Guid.NewGuid().ToString();
        licenseModel.securityStamp = DateTime.Now.ToString();
        licenseModel.nickname = "Test";

        APIHelper.MyDelegate del = DelegateMethod;   
        
        StartCoroutine(APIHelper.PostLicenseInfo(licenseModel , del));
    }
    
    public void OnCheckLicense(LicenseModel licenseModel , bool success)
    {
        if(!success && SceneManager.GetActiveScene().name != "Login")
        {
            SceneManager.LoadScene("Login");
        }
        else if(success && SceneManager.GetActiveScene().name == "Login")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            LicenseValid = true;
            UI?.gameObject.SetActive(true);
            game?.SetActive(true);
        }
    }

    public void DelegateMethod(LicenseModel licenseModel , bool success)
    {
        if(success)
        {
            PlayerPrefs.SetString("guid" , licenseModel.guid );
            PlayerPrefs.SetString("code" , licenseModel.referralCode );
            PlayerPrefs.Save();

            SceneManager.LoadScene("SampleScene");
        }
    }
}
