using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Show_hide : MonoBehaviour
{
    public GameObject bricks;
    
    CheckLicense checkLicense;

    void Start()
    {
        checkLicense = Camera.main.GetComponent<CheckLicense>();
    }

    public void Show()
    {
        if(!checkLicense.LicenseValid)
            return;
            
        bricks.SetActive(true);
    }
    public void Hide()
    {
        bricks.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
