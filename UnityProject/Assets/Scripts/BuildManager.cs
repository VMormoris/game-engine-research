using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Transform WeaponsCollection;
    public GameObject BallistaPrefab;

    public Color HoverColor;


    private void Awake()
    {
        GameContext.sBuildManager = this;
    }

    public GameObject GetBallista()
    {
        return BallistaPrefab;
    }
}
