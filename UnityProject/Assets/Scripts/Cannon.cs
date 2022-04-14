using UnityEngine;

public class Cannon : Turret
{
    public override void Shoot()
    {
        CannonBall script = mBullet.GetComponent<CannonBall>();
        if (script)
            script.Seek(mTarget);
    }
}
