using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //Refs
    public Transform EnemyPrefab;
    public Text CountDownText;
    //Other properties
    public float Interval = 5.1f;
    
    //Fields
    private float mCountdown = 2.1f;
    private int mWaveNumber = 1;

    void Update()
    {
        if(mCountdown <= 0.0f)
        {
            StartCoroutine(SpawnWave());
            mCountdown = Interval;
        }

        mCountdown -= Time.deltaTime;
        CountDownText.text = Mathf.Round(mCountdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Vector3 spawn = new Vector3(GameContext.sSpawn.position.x, 0.65f, GameContext.sSpawn.position.z);
        for (int i = 0; i < mWaveNumber; i++)
        {
            Instantiate(EnemyPrefab, spawn, Quaternion.Euler(0.0f, 0.0f, 0.0f), gameObject.transform);
            yield return new WaitForSeconds(0.5f);
        }
        mWaveNumber++;
    }
}
