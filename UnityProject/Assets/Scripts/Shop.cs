using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject BallistaPrefab;
    public GameObject CannonPrefab;

    public void PurchaseBallista()
    {
        GameContext.sBuildManager.SetSelectedObject(BallistaPrefab);
    }

    public void PurchaseCannon()
    {
        GameContext.sBuildManager.SetSelectedObject(CannonPrefab);
    }

}
