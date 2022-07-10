using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomGenerate : MonoBehaviour
{
    public float min_x , max_x;
    public int column_count;
    public float generate_delay;
    public List<GameObject> objects;

    public float distance;
    float lastTime = 0;

    List<GameObject> current_breaks;


    void Start()
    {
        distance  = (max_x - min_x) / (column_count - 1);
        current_breaks = GameObject.FindGameObjectsWithTag("break").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTime + generate_delay < Time.time)
        {
            lastTime = Time.time;
            int randomColumn = Random.Range(0 , column_count);
            int randomObject = Random.Range(0 , objects.Count);

            float newX = distance * randomColumn;

            var temp = GameObject.Instantiate(objects[randomObject]);
            temp.transform.SetParent(transform.parent);

            temp.transform.localPosition = new Vector3(newX + min_x , transform.localPosition.y , transform.localPosition.z);
            temp.transform.localRotation = new Quaternion();

            lastTime = Time.time;
        }
    }
}
