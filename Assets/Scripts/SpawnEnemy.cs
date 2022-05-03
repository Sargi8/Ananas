using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject gameObject;
    public UnityEngine.Object enemyRef;

    private void Start()
    {
        enemyRef = Resources.Load("Enemy");
    }

    private void Update()
    {
        
    }

    public void SpawnEnemyPoint()
    {
        Instantiate(gameObject, transform.position, transform.rotation);
    }
}
