using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform spawnPoint; // точка респавна зомби
    public GameObject player; // главный герой

    public float speed;

    private float _gravityForce;

    private CharacterController _characterController;


    void Start()
    {
        transform.position = spawnPoint.position;
        

    }

   
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position,player.transform.position, speed * Time.deltaTime); // враг идет за игроком.
        

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            

        }
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
        else _gravityForce = -1f;
    }
}
