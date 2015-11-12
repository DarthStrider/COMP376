using UnityEngine;
using System.Collections;

public class sBoostUp : MonoBehaviour {
    public GameObject boostbar;
    public sBoost boost;
    public float power;
    float current=5;
	// Use this for initialization
	void Start () {
        boostbar = GameObject.FindGameObjectWithTag("canvas");
    boost = boostbar.GetComponent<sBoost>();
        power = 15;
    }
	
	// Update is called once per frame
	void Update () {
        current = boost.getCurrentBoost();
	}

    public void checkDestroy()
    {
   
    }

   

}

