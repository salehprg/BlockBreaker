using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_hide : MonoBehaviour
{
    public StartForce extball;
    public GameObject bricks;
    // Start is called before the first frame update
    void Start()
    {

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
