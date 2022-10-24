using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float size = 1f;
    public float energyAmount = 10f;
    public float seedChance = 1f;
    public float decayTime = 30f;
    public float flingDistance = 2f;
    public Tree parentTree;

    public bool isSeed;
    private float creationTime;


    Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)); // Trig is fun
    }


    // Start is called before the first frame update
    void Start()
    {
        float randAngle = Random.Range(1, 12) * 30;
        transform.Translate(VectorFromAngle(randAngle),Space.Self);
        creationTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceCreation = Time.timeSinceLevelLoad - creationTime;

        if(timeSinceCreation >= decayTime)
        {
            Instantiate(parentTree, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
