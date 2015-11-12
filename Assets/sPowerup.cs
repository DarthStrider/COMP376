using UnityEngine;
using System.Collections;

public class sPowerup : MonoBehaviour {
    public GameObject boost;
    public float up;
    float timeElapse;
    bool exit;
    
	// Use this for initialization
	void Start () {
        up = 4;
        Instantiate(boost, transform.position + new Vector3(0,up,0), Quaternion.identity);
        exit = false;
	}
	
	// Update is called once per frame
	void Update () {
        timeElapse += Time.deltaTime;
        if (exit == true)
        {
            reInstantiate();
        }
	}

    void reInstantiate()
    {
        if(timeElapse > 7.0f)
        {
            Instantiate(boost, transform.position + new Vector3(0, up, 0), Quaternion.identity);
            exit = false;
        }
    }

    void OnCollisionExit(Collision col)
    {
        timeElapse = 0;
        exit = true;
    }
    }
