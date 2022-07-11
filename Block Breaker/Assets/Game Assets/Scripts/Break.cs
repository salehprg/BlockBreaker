using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Break : MonoBehaviour
{
    public int hp = 2;
    public int minhp = 2;
    public int maxhp = 6;
    public Color light;
    public Color veryhard;
    public ParticleSystem exp;

    public Vector3 newPos;

    int currentHit = 0;
    float h_l = 0 ,  s = 0 , v = 0;
    float h_h = 0;
    
    public List<GameObject> powerups;
    public Item item;
        
    void Start()
    {
        hp = Random.Range(minhp , maxhp);

        newPos = transform.localPosition;

        Color.RGBToHSV(light , out h_l , out s , out v);
        Color.RGBToHSV(veryhard , out h_h , out s, out v);

        float h = map(hp , 0 , 5 , h_l , h_h);

        Color temp = Color.HSVToRGB(h , s , v);

        this.GetComponent<Renderer>().material.SetColor("_Color" , temp);

        item =  GetComponentInChildren<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition , newPos , Time.deltaTime * 5);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "ball"){
            hp--;
            float h;

            h = map(hp , 0 , 5 , h_l , h_h);

            Color temp = Color.HSVToRGB(h , s , v);

            this.GetComponent<Renderer>().material.SetColor("_Color" , temp);
            
        }
        if (hp<=0){
            GameObject.Instantiate(exp,transform.position,new Quaternion());
            Destroy(gameObject);
        }
        
    }
    private void OnDestroy() {
        int index = Random.Range(0,powerups.Count);
        var temp = GameObject.Instantiate(powerups[index]);
        temp.transform.SetParent(transform.parent);
    }
}
