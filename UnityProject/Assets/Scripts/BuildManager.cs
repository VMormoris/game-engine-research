using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Transform WeaponsCollection;
    private GameObject mSelectedTurret;

    public Color HoverColor;


    private void Awake()
    {
        GameContext.sBuildManager = this;
    }

    public void SetSelectedObject(GameObject selection)
    {
        mSelectedTurret = selection;
    }

    public GameObject GetSelectedTurret()
    {
        return mSelectedTurret;
    }

}
