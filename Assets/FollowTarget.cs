using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    Transform mTarget;
    public Transform bTarget;
    [SerializeField]
    Vector3 mOffset;
    void Start()
    {
      
    }
    void Update ()
    {
        Vector3 zero = Vector3.zero;
        transform.position = mTarget.position + mOffset;
        transform.position = Vector3.SmoothDamp(mTarget.position + mOffset, mTarget.position, ref zero, 0.3f);

        if (Input.GetKey(KeyCode.L))
        {
            transform.position = Vector3.SmoothDamp(bTarget.position + mOffset, mTarget.position, ref zero, 0.3f);
        }
    }

}
