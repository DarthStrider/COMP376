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
    Vector3 lastPosition;
    public Rigidbody rb;
    public float push;
    Vector3 dir;
    public GameObject car;
    public GameObject b;
    public sBoostUp bs;
    public GameObject bBar;
    public sBoost bScript;
    public float boosting;
    float increaseSpeed;
    public float ratio;
    float boost;
    float powerInput;
    float turnInput;
    float turnSpeed;
    void Start() { 
        rb = car.GetComponent<Rigidbody>();
        bBar = GameObject.FindGameObjectWithTag("canvas");
        bScript = bBar.GetComponent<sBoost>();
        increaseSpeed = 1;
        turnSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        lastPosition = transform.position;
        boost = bScript.getCurrentBoost();
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
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

        speed = acc * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * (speed), ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-(transform.forward) * (speed/2), ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0.5f, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -0.5f, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            if (boost > 0)
            {
                bScript.decreaseBoost(boosting);
                rb.AddForce(transform.up * speed, ForceMode.Acceleration);
                rb.constraints = ~RigidbodyConstraints.FreezePositionY;
                rb.constraints= RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

            }
        }
        else
        {
            //rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        }

        if (Input.GetAxis("Vertical") == 0)
        {
            rb.velocity=new Vector3 (0.0f, 0, 0.0f);
        }
    }


    void OnCollisionEnter(Collision  col)
    {

        if (col.gameObject.tag == "terrain")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        }
        if (col.gameObject.tag == "border")
        {
            transform.position = lastPosition;
        }

    }



}