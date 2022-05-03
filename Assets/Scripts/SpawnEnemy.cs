using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] _enemy;
    public Transform[] _spawnPoints;
    public UnityEngine.Object enemyRef;

    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;


    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, _enemy.Length);
            randPosition = Random.Range(0, _spawnPoints.Length);
            Instantiate(_enemy[rand], _spawnPoints[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    public void SpawnEnemyPoint()
    {
        Instantiate(gameObject, transform.position, transform.rotation);
    }
}
