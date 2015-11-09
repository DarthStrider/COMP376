using UnityEngine;
using System.Collections;

public class sBoost : MonoBehaviour
{
    public float maxBoost = 100;
    public float currentBoost;
    public float difference;
    public GameObject boostBar;


    public bool dead = false;

    // Use this for initialization
    void Start()
    {
        currentBoost = 33;
        difference = currentBoost / maxBoost;
        setBoostBar(difference);
 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float getCurrentBoost()
    {
        return currentBoost;
    }
    public void decreaseBoost(float x)
    {
        if (currentBoost + x > 0)
        {
            currentBoost -= x;
            difference = currentBoost / maxBoost;
            setBoostBar(difference);
        }
        else
        {
            currentBoost = 0;
            setBoostBar(0);
        }
    }

    public void increaseBoost(float x)
    {
        if (currentBoost + x < maxBoost)
        {
            currentBoost += x;
            difference = currentBoost / maxBoost;
            setBoostBar(difference);
        }
        else
        {
            currentBoost = 100;
            setBoostBar(1);
        }
    }

    void setBoostBar(float d)
    {
        if (d > 0 || d > 1)
        {
            
            boostBar.transform.localScale = new Vector3(d, boostBar.transform.localScale.y, boostBar.transform.localScale.z);
        }
    }
}
