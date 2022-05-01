using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform spawnPoint; // ����� �������� �����
    public GameObject player; // ������� �����

    public float speed;
    public float enemyHP = 3f;

    void Start()
    {
        transform.position = spawnPoint.position;
        

    }

   
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position,player.transform.position, speed * Time.deltaTime); // ���� ���� �� �������.
        if (enemyHP <= 0)
        {
            Destroy(gameObject);

        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          

        }
    }
}
