using UnityEngine;

public class Ballista : Turret
{
    public override void Shoot()
    {
        Arrow script = mBullet.GetComponent<Arrow>();
        if(script)
            script.Seek(mTarget);
    }
}
