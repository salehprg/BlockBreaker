using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public RandomGenerate randomGenerate;
    Transform game_plane;


    int currentHit = 0;
    float h_l = 0 ,  s = 0 , v = 0;
    float h_h = 0;
    
    

    bool hasItem = false;

        
    void Start()
    {
        game_plane = transform.parent.parent;

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

        randomGenerate = GameObject.FindGameObjectWithTag("generators").GetComponent<RandomGenerate>();
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

        Camera.main.GetComponent<CollisionCounterScript>().addScore(amount);
        
        if (hp <= 0)
        {
            var particle = GameObject.Instantiate(exp,transform.position,new Quaternion());
            Destroy(particle.gameObject , 2);
            if(hasItem)
            {
                int index = Random.Range(0,powerups.Count);
                var temp_go = GameObject.Instantiate(powerups[index],transform.position , new Quaternion() , game_plane);

                temp_go.transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y + 0.2f , transform.localPosition.z);
                temp_go.transform.localRotation = powerups[index].transform.localRotation;
            }

            var location = GameObject.Instantiate(new GameObject($"Location{this.name}") , transform.position , transform.rotation , transform.parent);
            randomGenerate.CheckEmptyLocations(location.transform);
            Destroy(gameObject);
        }
    }


    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
    
}
