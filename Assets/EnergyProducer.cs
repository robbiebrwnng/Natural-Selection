using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class EnergyProducer : MonoBehaviour
{

    public GameObject energyObject;
    public float minFlingDistance;


    Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)); // Trig is fun
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randAngle = Random.Range(1, 12)*30;

        Vector2 randVector = VectorFromAngle(randAngle);

       // Instantiate(energyObject,placement,Quaternion.FromToRotation(transform.position, placement),gameObject.transform);
    }
}
