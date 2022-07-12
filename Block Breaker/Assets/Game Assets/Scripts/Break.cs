using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Break : MonoBehaviour
{
    public int hp = 2;
    public int minhp = 2;
    public int maxhp = 6;
    public float chance_drop;
    public Color light;
    public Color veryhard;
    public ParticleSystem exp;
    public Vector3 newPos;
    public List<GameObject> powerups;
    public GameObject chestBox;



    int currentHit = 0;
    float h_l = 0 ,  s = 0 , v = 0;
    float h_h = 0;
    
    

    bool hasItem = false;

        
    void Start()
    {
        int itemrnd = Random.Range(0,100);

        if(itemrnd < chance_drop * 100)
        {
            hasItem = true;
            var temp_chest = GameObject.Instantiate(chestBox , transform.position, new Quaternion() , this.transform);
            temp_chest.transform.localPosition = new Vector3(temp_chest.transform.localPosition.x,
                                                                temp_chest.transform.localPosition.y + 0.2f,
                                                                temp_chest.transform.localPosition.z - 0.5f);
        }


        hp = Random.Range(minhp , maxhp + 1);

        newPos = transform.localPosition;

        Color.RGBToHSV(light , out h_l , out s , out v);
        Color.RGBToHSV(veryhard , out h_h , out s, out v);

        float h = map(hp , 1 , 5 , h_l , h_h);

        Color temp = Color.HSVToRGB(h , s , v);

        this.GetComponent<Renderer>().material.SetColor("_Color" , temp);
    }


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition , newPos , Time.deltaTime * 5);
    }

    public void Damage(int amount)
    {
        hp -= amount;

        float h;

        h = map(hp , 1 , 5 , h_l , h_h);

        Color temp = Color.HSVToRGB(h , s , v);

        this.GetComponent<Renderer>().material.SetColor("_Color" , temp);

        if (hp <= 0)
        {
            GameObject.Instantiate(exp,transform.position,new Quaternion());
            Destroy(gameObject);
        }
    }


    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    private void OnDestroy() 
    {
        if(hasItem)
        {
            int index = Random.Range(0,powerups.Count);
            var temp = GameObject.Instantiate(powerups[index],transform.position , new Quaternion() , transform.parent);
            temp.transform.localPosition = transform.localPosition;
            temp.transform.localRotation = powerups[index].transform.localRotation;
        }
    }
}
