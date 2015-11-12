using UnityEngine;
using System.Collections;


public class sPlayer : MonoBehaviour
{
    // Use this for initialization
    public float acc;
    float speed;
    public float rotationSpeed;
    float translation;
    float rotation;
    public Rigidbody rb;
    public float push;
    Vector3 dir;
    public GameObject b;
    public sBoostUp bs;
    public GameObject bBar;
    public sBoost bScript;
    public float power;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bScript = bBar.GetComponent<sBoost>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        translation = Input.GetAxis("Vertical") * speed;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);
        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        movement();
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = acc * Time.deltaTime;
        }
        else
        {
            speed = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
      
            //rb.AddForce(speed, 0, 0, ForceMode.Force);
            //rb.AddForce(Vector3.forward* speed);
            transform.Translate(Vector3.left * speed);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(Vector3.right * speed);
        }
    }


    void OnCollisionEnter(Collision  col)
    {
        if (col.gameObject.tag == "Boost")
        {

            if (bScript.getCurrentBoost() < 100)
            {
                Destroy(col.gameObject);
                bScript.increaseBoost(power);
            }
        }
        if (col.gameObject.tag == "ball")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(dir * push,ForceMode.Force);
        }
    }



}