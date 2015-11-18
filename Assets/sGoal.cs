using UnityEngine;
using System.Collections;

public class sGoal : MonoBehaviour
{
    public GameObject Canvas;
    sTime scored;

    // Use this for initialization
    void Start()
    {
        scored = Canvas.GetComponent<sTime>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ball")
        {
            scored.incrementScore();
            Destroy(col.gameObject);
        }
    }
}