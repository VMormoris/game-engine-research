
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    void Awake() { GameContext.sSpawn =  gameObject.transform; }

}
