using UnityEngine;
using System.Collections;

public class sBoostUp : MonoBehaviour {
    public GameObject bBar;
    public sBoost bScript;
    public float power;
    float current;
	// Use this for initialization
	void Start () {
        bBar = GameObject.FindGameObjectWithTag("canvas");
        bScript = bBar.GetComponent<sBoost>();
        power = 15;
    }
	
	// Update is called once per frame
	void Update () {
        current = bScript.getCurrentBoost();
	}

 void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player")
        {

            if (bScript.getCurrentBoost() < 100)
            {
                Destroy(this.gameObject);
                bScript.increaseBoost(power);
            }
        }
    }

   

}

