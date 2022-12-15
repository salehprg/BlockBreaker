using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Show_hide : MonoBehaviour
{
    public StartForce extball;
    public GameObject bricks;
    public AudioClip _audio1;
    public GameObject _explode1;
    public AudioClip _audio2;
    public GameObject _explode2;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void audio1()
    {
        GetComponent<AudioSource>().PlayOneShot(_audio1);
        //Destroy(_explode1.gameObject);
    }

    public void explode1()
    {
        _explode1.SetActive(true);
        //Destroy(_explode1.gameObject);
    }

    public void audio2()
    {
        GetComponent<AudioSource>().PlayOneShot(_audio2);
        //Destroy(_explode1.gameObject);
    }
    public void explode2()
    {
        _explode2.SetActive(true);
        //Destroy(_explode2.gameObject);
    }

    public void Show()
    {
        extball.enabled=true;
        bricks.SetActive(true);
    }
    public void Hide()
    {
        extball.enabled=false;
        bricks.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
