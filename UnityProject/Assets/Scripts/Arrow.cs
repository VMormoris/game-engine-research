using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Attributes")]
    public float Speed = 70.0f;

    public Transform Peak;

    private Transform mTarget = null;

    /**
     * Sets target to be followed by the arrow
     * @param target Tranform of the enenemy gameobject that we should follow
     */
    public void Seek(Transform target) { mTarget = target; }

    // Update is called once per frame
    void Update()
    {
        if (!mTarget)
            return;

        //Move
        Vector3 dir = mTarget.position - transform.position;
        transform.position += dir.normalized * Time.deltaTime * Speed;

        //Check collision
        float distance = Vector3.Distance(Peak.position, mTarget.position);
        if(distance <= 0.24)//Hit target
        {
            Destroy(gameObject);
            return;
        }
    }
}
