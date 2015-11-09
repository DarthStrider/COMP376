using UnityEngine;
using System.Collections;

public class sBoostUp : MonoBehaviour {
    public GameObject boostbar;
    public sBoost boost;
    public float power;
    float current;
	// Use this for initialization
	void Start () {
        boostbar = GameObject.Find("Canvas");
    boost = boostbar.GetComponent<sBoost>();
        power = 15;
    }
	
	// Update is called once per frame
	void Update () {
        current = boost.getCurrentBoost();
	}

    

    void OnTriggerEnter(Collider other)
    {
        if (current < 100)
        {
            boost.increaseBoost(power);
            Destroy(this);
        }
    }

}

