using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    public float size = 1f;
    public float timeToGrow = 30f;
    public int maxNumberOfFruit = 20;
    public float paceOfDrop = 3f;
    public GameObject seed;

    private float creationTime;
    private int fruitCreated = 0;

    void Start()
    {
        creationTime = Time.timeSinceLevelLoad;
        transform.localScale = new Vector3(size,size);

        if (creationTime > Time.realtimeSinceStartup)
        {
            transform.position = seed.transform.position;
        };
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceCreation = Time.timeSinceLevelLoad - creationTime;

        
        if (timeSinceCreation > timeToGrow)
        {
            if (timeSinceCreation - timeToGrow % paceOfDrop == 0 & fruitCreated < maxNumberOfFruit)
            {
                Instantiate(seed, transform.position, Quaternion.identity);
                fruitCreated = fruitCreated + 1;
            }
        }

    }
}
