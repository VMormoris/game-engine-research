using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float Speed = 2.0f;
    public float ColliderRadius = 0.24f;
    
    private Transform entt;
    private int mWaypointIndex = 0;

    void Start()
    {
        entt = transform;
    }

    void Awake()
    {
        GameContext.sEnemies.Add(gameObject);
    }

    void Update()
    {
        Vector3 current = new Vector3(entt.position.x, 0.0f, entt.position.z);
        Transform waypoint = GameContext.sWaypoints[mWaypointIndex];
        Vector3 target = new Vector3(waypoint.position.x, 0.0f, waypoint.position.z);
        Vector3 dir = (target - current).normalized;

        entt.Translate(dir.normalized * Time.deltaTime * Speed);

        if(Vector3.Distance(current, target) < 0.2f)
            mWaypointIndex++;

        if (mWaypointIndex >= GameContext.sWaypoints.Length)
        {
            Destroy(gameObject);
            return;//It's important to return when destroying an object
        }
    }

    private void OnDestroy()
    {
        GameContext.sEnemies.Remove(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, ColliderRadius);
    }
}
