using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public float hp = 2.0f;
    public Color light;
    public Color veryhard;
    
    int currentHit = 0;
    float h_l = 0 ,  s = 0 , v = 0;
    float h_h = 0;
    public ParticleSystem exp;
        
    void Start()
    {
        Color.RGBToHSV(light , out h_l , out s , out v);
        Color.RGBToHSV(veryhard , out h_h , out s, out v);

        float h = map(hp , 0 , 5 , h_l , h_h);

        Color temp = Color.HSVToRGB(h , s , v);

        this.GetComponent<Renderer>().material.SetColor("_Color" , temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "ball")
        {
            hp--;
            float h;

            h = map(hp , 0 , 5 , h_l , h_h);

            Color temp = Color.HSVToRGB(h , s , v);

            this.GetComponent<Renderer>().material.SetColor("_Color" , temp);
        }

        if(hp <= 0)
        {
            GameObject.Instantiate(exp,transform.position,new Quaternion());
            Destroy(this.gameObject);
        }
    }
}
