using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject mTurret;
    private Color mStartColor;
    private Material mMaterial;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mMaterial = mr.materials[1];
        mStartColor = mMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(mTurret)
        {
            Debug.Log("Can't be placed here!");
            return;
        }

        mMaterial.color = GameContext.sBuildManager.HoverColor;
    }

    private void OnMouseExit()
    {
        mMaterial.color = mStartColor;
    }

    private void OnMouseDown()
    {
        if (mTurret)
            return;

        BuildManager bm = GameContext.sBuildManager;
        Vector3 position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        GameObject prefab = bm.GetSelectedTurret();
        if(prefab)
            mTurret = Instantiate(prefab, position, Quaternion.Euler(0.0f, 0.0f, 0.0f), bm.WeaponsCollection); 
    }

}
