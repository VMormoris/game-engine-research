using UnityEngine;

public class Waypoints : MonoBehaviour
{
    void Awake()
    {
        //please
        Transform entt = gameObject.transform;
        GameContext.sWaypoints = new Transform[entt.childCount];
        for (int i = 0; i < entt.childCount; i++)
            GameContext.sWaypoints[i] = entt.GetChild(i);
    }

}
