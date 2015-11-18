using UnityEngine;
using System.Collections;

public class sBall : MonoBehaviour
{

    public GameObject ball;
    public GameObject boost;
    public float explosive;
    public float airMass;
    public float groundMass;
    public float power;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


    }


    void OnCollisionEnter(Collision col)
    {

     if (col.gameObject.tag == "goal")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "pillar")
        {
            Vector3 y =new Vector3 (0,1,0);
            //rb.AddForce(y*explosive, ForceMode.Force);
            rb.AddExplosionForce(explosive, col.transform.position, 3, 0.0f,ForceMode.Acceleration);
            Debug.Log("here");
        }

        if (col.gameObject.tag == "Player")
        {
            //rb.AddForce(transform.forward * power*Time.deltaTime, ForceMode.Impulse);
        }

        if (col.gameObject.tag == "terrain")
        {
            rb.mass = groundMass;
        }
        if (col.gameObject.tag != "terrain")
        {
            rb.mass = airMass;
        }


    }
}