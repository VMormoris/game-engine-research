using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{
    private const float COLISION_BOUND = 2 * 0.24f;
    
    [Header("References")]
    public Transform Peak;
    public Transform ImpactEffect;

    public override bool IsColliding()
    {
        float distance = Vector3.Distance(Peak.position, mTarget.position);
        if (distance <= COLISION_BOUND)//Hit target
        {
            Instantiate(ImpactEffect, Peak.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            Destroy(gameObject);
            return true;
        }
        return false;
    }

}
