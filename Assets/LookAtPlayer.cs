using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    float mSmoothness;
    public GameObject player;
    Transform playerTransform;
    public GameObject ball;
    Transform ballTransform;

    void Start ()
    {
        playerTransform = player.transform;
        ballTransform = ball.transform;
    }

    void Update ()
    {
        Quaternion targetQuaternion = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * mSmoothness);

        if (Input.GetKey(KeyCode.L))
        {
            Quaternion ballQuaternion = Quaternion.LookRotation(ballTransform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, ballQuaternion, Time.deltaTime * mSmoothness);
        }
    }
}
