using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform spawnPoint; // ����� �������� �����
    public GameObject player; // ������� �����

    public Health playerHealth; // ����� ��

    public Health enemyHealth; // ����� �����

    public float speed;

    public float enemyDamage = 1f;

    private bool inFire = false;
    private bool nowAttack = true; // ����� �� ���� ��������� ������

    private float _gravityForce;

    private CharacterController _characterController;




    void Start()
    {
        transform.position = spawnPoint.position;
        

    }

   
    void Update()
    {
        if (inFire == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); // ���� ���� �� �������
        }
       

        

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && nowAttack)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 4f,ForceMode.Impulse);
            StartCoroutine(PlayerAttack());
           




        }
    }

    private void OnTriggerEnter(Collider thisTrigger) // ��� �������� � ������
    {
        if (thisTrigger.gameObject.tag == "Fire")
        {
            inFire = true;
            

        }
        
    }
    private void OnTriggerExit(Collider thissTrigger) // ��� ����� �� ������
    {
        if (thissTrigger.gameObject.tag == "Fire")
        {
            
            inFire = false;
        }

    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
        else _gravityForce = -1f;
    }
    IEnumerator PlayerAttack() // �������� 1 ������� ����� ����� �����
    {
        nowAttack = false;
        playerHealth.TakeHit(enemyDamage);
        yield return new WaitForSeconds(1f);
        nowAttack = true;
    }
}
