using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float wait_time;
    public float speed;
    public GameObject Ball;

    bool gameFinished = false;
    float time;
    CheckLicense checkLicense;

    
    void Start()
    {
        time = Time.time + wait_time;
        checkLicense = Camera.main.GetComponent<CheckLicense>();
        Ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        if(!checkLicense.LicenseValid || gameFinished)
            return;
            
        Ball = GameObject.FindGameObjectWithTag("ball");
        if (Time.time > time && Ball != null)
        {
            gameObject.transform.Rotate(0,speed*Time.deltaTime,0);
        }
        else if(Ball == null)
        {
            print("game Over");
            var score = Camera.main.GetComponent<CollisionCounterScript>().score;
            PlayerPrefs.SetInt("score" , score);
            Camera.main.GetComponent<ScoreBorads>().SubmitScore(score);
            gameFinished = true;
        }
    }
}
