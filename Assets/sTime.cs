using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class sTime : MonoBehaviour {
    public float maxTime;
   public static int goal=0;
    public GameObject End;
    public GameObject car;
    public GameObject goalScript;
    public static float currentTime=45;
    float difference;
    float deltaTime;
    public GameObject timeBar;
    // Use this for initialization
     
        void Awake()
    {
       
    }
    

    void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
        goalScript.GetComponent<Text>().text = "" + goal.ToString();
        currentTime -= Time.deltaTime;
        difference = currentTime / maxTime;
        if (currentTime > 0)
        {
            timeBar.transform.localScale = new Vector3(difference, timeBar.transform.localScale.y, timeBar.transform.localScale.z);
        }
        if (currentTime <= 0)
        {
            End.SetActive(true);
            Destroy(car.GetComponent<sPlayer>());
            car.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    public void incrementScore ()
    {
        goal++;
        Application.LoadLevel("game");
    }

    public void restartGame(int index)
    {
        Application.LoadLevel("game");
        goal = 0;
        currentTime = maxTime;
    }
}
