using UnityEngine;
using System.Collections;

public class sBall : MonoBehaviour
{

    public GameObject ball;
    public GameObject boost;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(ball.gameObject.GetComponent<Collider>(), boost.gameObject.GetComponent<Collider>());

    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Boost")
        {
            Physics.IgnoreCollision(ball.gameObject.GetComponent<Collider>(), boost.gameObject.GetComponent<Collider>());
        }

        if (col.gameObject.tag == "booster")
        {
            Physics.IgnoreCollision(ball.gameObject.GetComponent<Collider>(), col.collider);
        }

    }
}