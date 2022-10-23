using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{


    public float sightDistance;
    public bool PlayerControl;
    public float MoveSpeed;

    private float EnergyAmount = 100f;
    private Transform target;
    private Quaternion direction;

    public GameObject FindClosestFruit()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Fruit");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fruit")
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Fruit")
        {
            target = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        direction = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerControl)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            transform.position = new Vector2(transform.position.x + (h * MoveSpeed * Time.deltaTime), transform.position.y + (v * MoveSpeed * Time.deltaTime));
        }
        else
        {
            if(target != null)
            {
                direction = Quaternion.FromToRotation(transform.position, target.position);
                transform.rotation = direction;
                transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
            }

            else
            {
                direction = Quaternion.FromToRotation(transform.position, FindClosestFruit().transform.position);
                transform.rotation = direction;
                transform.position = Vector2.MoveTowards(transform.position, FindClosestFruit().transform.position, MoveSpeed * Time.deltaTime);
            }
        }
    }
}
