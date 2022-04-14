using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float Range = 15.0f;
    public float FireRate = 1.0f;
    public float FireCountdown = 0.0f;

    [Header("Properties")]
    public float TurnSpeed = 10.0f;

    [Header("Refernces")]
    public Transform RotationAnchor;
    public Transform BulletSpot;
    public Transform mBullet;

    [Header("Prefabs Refs")]
    public Transform BulletPrefab;

    protected Transform mTarget = null;

    private bool mLockVertically = true;
    ///------- Constructor(s) -------
    public Turret() { }
    public Turret(bool lockVertically) { mLockVertically = lockVertically; }

    /// ------- -------
    
    /// ------- Unity hooks -------
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        FireCountdown -= Time.deltaTime;
        if (mTarget == null)
            return;

        LockOnTarget();

        if (FireCountdown <= 0.0f)
        {
            Shoot();
            Invoke("Reload", 1 / (2 * FireRate));
            FireCountdown = 1.0f / FireRate;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    /// ------- -------

    /// ------- Other methods -------
    void UpdateTarget()
    {
        if(mTarget)
        {
            float distance = Vector3.Distance(transform.position, mTarget.position);
            if (distance < Range)
                return;
            else
                mTarget = null;
        }

        object[] enemies = GameContext.sEnemies.ToArray();
        float minDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach(GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (minDistance < Range)
                mTarget = nearestEnemy.transform;
        else
            mTarget = null;
    }

    void Reload()
    {
       mBullet = Instantiate(BulletPrefab, BulletSpot);
    }    

    void LockOnTarget()
    {
        //Rotate whole object around Y-axis to follow it's movents
        Vector3 dir = mTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);

        //Aim by rotating subobject around X-axis (makes it more realistic)
        if(mLockVertically)
        {
            dir = mTarget.position - RotationAnchor.position;
            lookRotation = Quaternion.LookRotation(dir);
            rotation = Quaternion.Lerp(RotationAnchor.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
            RotationAnchor.rotation = Quaternion.Euler(rotation.x, rotation.y, 0.0f);
        }
    }
    public abstract void Shoot();
    /// ------- -------
}
