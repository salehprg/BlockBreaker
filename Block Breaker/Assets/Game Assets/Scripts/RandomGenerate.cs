using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomGenerate : MonoBehaviour
{
    public float min_x , max_x;
    public int column_count;
    public int obj_per_row;
    public float generate_delay;
    public List<GameObject> objects;

    public float distance;
    float lastTime = 0;

    List<GameObject> current_bricks;


    void Start()
    {
        distance  = (max_x - min_x) / (column_count - 1);
        //current_bricks = GameObject.FindGameObjectsWithTag("brick").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTime + generate_delay < Time.time)
        {
            lastTime = Time.time;

            int randomColumn = Random.Range(0 , column_count);
            int randomObject = Random.Range(0 , objects.Count);
            int randomObjectRow = Random.Range(0 , obj_per_row+1);
            
            List<float> spawned_x = new List<float>();

            for(int i = 0; i < randomObjectRow; i++)
            {
                // while(spawned_x.Exists(x => x == randomColumn))
                // {
                //     randomColumn = Random.Range(0 , column_count);
                // }

                // spawned_x.Add(randomColumn);

                float newX = distance * randomColumn;

                var temp = GameObject.Instantiate(objects[randomObject]);

                temp.transform.SetParent(transform.parent);

                temp.transform.localPosition = new Vector3(newX + min_x , transform.localPosition.y + 0.2f , transform.localPosition.z);
                temp.transform.localRotation = objects[randomObject].transform.localRotation;

                //current_bricks.Add(temp);
                //current_bricks.RemoveAll(x => x == null);
            }

            // foreach(var brick in current_bricks)
            // {
            //     Break temp = brick.GetComponent<Break>();
            //     temp.newPos = new Vector3(brick.transform.localPosition.x, 
            //                                                 brick.transform.localPosition.y,
            //                                                 brick.transform.localPosition.z + 0.68f);

            // }

            lastTime = Time.time;
        }
    }
}
