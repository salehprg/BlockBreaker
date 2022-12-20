using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomGenerate : MonoBehaviour
{
    public float min_x, max_x;
    public int column_count;
    public int obj_per_row;
    public float generate_delay;
    public GameObject Brick;
    public List<GameObject> objects;

    public float distance;
    float lastTime = 0;

    public List<Transform> bricks_empty_locations;


    void Start()
    {
        bricks_empty_locations = new List<Transform>();
        distance = (max_x - min_x) / (column_count - 1);
    }

    public void CheckEmptyLocations(Transform brickTransform)
    {
        bricks_empty_locations.Add(brickTransform);
        bool generate = false;
        int count = 1;

        if (bricks_empty_locations.Count > 5)
        {
            float rand = Random.Range(0.0f, 1.0f);
            if (rand > 0.5)
            {
                generate = true;
            }
        }
        if (bricks_empty_locations.Count > 15)
        {
            float rand = Random.Range(0.0f, 1.0f);
            if (rand > 0.3)
            {
                generate = true;
                count = 2;
            }
        }
        if (bricks_empty_locations.Count > 30)
        {
            generate = true;
            count = 4;
        }

        if (generate)
        {
            for (int i = 0; i < count; i++)
            {
                if (bricks_empty_locations.Count > 0)
                {
                    int location = Random.Range(0, bricks_empty_locations.Count);

                    var temp = GameObject.Instantiate(Brick, bricks_empty_locations[location].position, bricks_empty_locations[location].rotation, bricks_empty_locations[location].parent);
                    Destroy(bricks_empty_locations[location].gameObject);
                    bricks_empty_locations.RemoveAt(location);
                }
            }
        }
    }
    void Update()
    {
        if (lastTime + generate_delay < Time.time)
        {
            lastTime = Time.time;

            int randomColumn = Random.Range(0, column_count);
            int randomObject = Random.Range(0, objects.Count);
            int randomObjectRow = Random.Range(0, obj_per_row + 1);

            List<float> spawned_x = new List<float>();

            for (int i = 0; i < randomObjectRow; i++)
            {
                float newX = distance * randomColumn;

                var temp = GameObject.Instantiate(objects[randomObject]);

                temp.transform.SetParent(transform.parent);

                temp.transform.localPosition = new Vector3(newX + min_x, transform.localPosition.y + 0.2f, transform.localPosition.z);
                temp.transform.localRotation = objects[randomObject].transform.localRotation;

            }

            lastTime = Time.time;
        }
    }
}
