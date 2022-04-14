using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    public float Speed = 10.0f;

    protected Transform mTarget = null;
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
        if (IsColliding())
            return;
    }

    public abstract bool IsColliding();
}
