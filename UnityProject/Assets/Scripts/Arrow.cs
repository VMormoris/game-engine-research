using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Attributes")]
    public float Speed = 70.0f;

    [Header("References")]
    public Transform Peak;
    public Transform ImpactEffect;

    private Transform mTarget = null;
    private bool mSeeking = false;

    /**
     * Sets target to be followed by the arrow
     * @param target Tranform of the enenemy gameobject that we should follow
     */
    public void Seek(Transform target)
    {
        mTarget = target;
        mSeeking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mTarget && mSeeking)
        {
            Destroy(gameObject);
            return;
        }
        else if (!mTarget)
            return;

        //Move
        Vector3 dir = mTarget.position - transform.position;
        transform.position += dir.normalized * Time.deltaTime * Speed;

        //Check collision
        float distance = Vector3.Distance(Peak.position, mTarget.position);
        if(distance <= 0.3)//Hit target
        {
            Instantiate(ImpactEffect, Peak.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            Destroy(gameObject);
            return;
        }
    }
}
