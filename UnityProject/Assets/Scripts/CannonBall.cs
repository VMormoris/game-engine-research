using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Bullet
{
    private const float COLLISION_BOUND = 0.15f + 0.24f;
    
    public Transform ImpactEffect;

    public override bool IsColliding()
    {
        float distance = Vector3.Distance(transform.position, mTarget.position);
        if(distance <= COLLISION_BOUND)
        {
            Instantiate(ImpactEffect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
