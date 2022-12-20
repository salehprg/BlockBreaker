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
    public GameObject loading;
    public RectTransform canvas;
    public TMPro.TMP_InputField input_license;
    public TMPro.TMP_InputField input_nickname;
    GameObject _loading;


    void Awake()
    {
        // if(SceneManager.GetActiveScene().name == "SampleScene" || SceneManager.GetActiveScene().name == "MainMenu")
        // {
        //     game.SetActive(false);
        //     UI.gameObject.SetActive(false);

        //     string license = PlayerPrefs.GetString("code");
        //     string guid = PlayerPrefs.GetString("guid");

        //     if(string.IsNullOrEmpty(license))
        //     {
        //         try
        //         {
        //             SceneManager.LoadScene("Login");
        //         }
        //         catch
        //         {
        //             Application.Quit();
        //         }
        //     }

        //     LicenseModel licenseModel = new LicenseModel();
        
        //     licenseModel.referralCode = license;
        //     licenseModel.guid = guid;

        //     APIHelper.MyDelegate del = OnCheckLicense;   

        //     StartCoroutine(APIHelper.PostLicenseInfo(licenseModel , del));
        
        // }

        // if(SceneManager.GetActiveScene().name == "Login")
        // {
        //     string license = PlayerPrefs.GetString("code");
        //     string guid = PlayerPrefs.GetString("guid");
            
        //     if(!string.IsNullOrEmpty(license))
        //     {
        //         LicenseModel licenseModel = new LicenseModel();
        
        //         licenseModel.referralCode = license;
        //         licenseModel.guid = guid;

        //         APIHelper.MyDelegate del = OnCheckLicense;   

        //         StartCoroutine(APIHelper.PostLicenseInfo(licenseModel , del));
        //     }
        // }

        if(DateTime.Now > new DateTime(2022 , 12 , 22 , 20 , 00 , 00))
        {
            _loading = Instantiate(loading , canvas.transform);
            _loading.GetComponentInChildren<TMPro.TMP_Text>().text = "Your Free Trial Expired !";
            Application.Quit();
        }
        else
        {
            LicenseValid = true;
            if (UI != null) UI.gameObject.SetActive(true);
            if (game != null) game.SetActive(true);
        }
    }
    
    public void SubmitLicense()
    {
        // _loading = Instantiate(loading , canvas.transform);

        // LicenseModel licenseModel = new LicenseModel();
        
        // string license = input_license.text;

        // licenseModel.referralCode = RSA.Encrypt(license);
        // licenseModel.guid = System.Guid.NewGuid().ToString();
        // licenseModel.securityStamp = DateTime.Now.ToString();
        // licenseModel.nickname = input_nickname.text;

        // APIHelper.MyDelegate del = DelegateMethod;   
        
        // StartCoroutine(APIHelper.PostLicenseInfo(licenseModel , del));

        if(input_license.text == "DEMO")
        {
            LicenseModel licenseModel = new LicenseModel();
            
            string license = input_license.text;

            licenseModel.referralCode = RSA.Encrypt(license);
            licenseModel.guid = System.Guid.NewGuid().ToString();
            licenseModel.securityStamp = DateTime.Now.ToString();
            licenseModel.nickname = input_nickname.text;

            PlayerPrefs.SetString("guid" , licenseModel.guid );
            PlayerPrefs.SetString("code" , licenseModel.referralCode );
            PlayerPrefs.SetString("nickname" , licenseModel.nickname );
            PlayerPrefs.Save();

            SceneManager.LoadScene("MainMenu");
        }
    }
    
    public void OnCheckLicense(LicenseModel licenseModel , bool success , string message)
    {
        if(!success && SceneManager.GetActiveScene().name != "Login")
        {
            SceneManager.LoadScene("Login");
        }
        else if(success && SceneManager.GetActiveScene().name == "Login")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            LicenseValid = true;
            if (UI != null) UI.gameObject.SetActive(true);
            if (game != null) game.SetActive(true);
        }
    }

    public void DelegateMethod(LicenseModel licenseModel , bool success , string message)
    {
        if(success)
        {
            Destroy(_loading);
            PlayerPrefs.SetString("guid" , licenseModel.guid );
            PlayerPrefs.SetString("code" , licenseModel.referralCode );
            PlayerPrefs.SetString("nickname" , licenseModel.nickname );
            PlayerPrefs.Save();

            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Destroy(_loading , 2);
            _loading.GetComponentInChildren<TMPro.TMP_Text>().text = message;
        }
    }
}
