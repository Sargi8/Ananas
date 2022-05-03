using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform spawnPoint; // ����� �������� �����
    public GameObject player; // ������� �����

    public Health playerHealth; // ����� ��

    public Animator anim;

    private Vector3 _moveVector;
    public float speed;

    public float enemyDamage = 1f;

    private bool inFire = false;
    private bool nowAttack = true; // ����� �� ���� ��������� ������

    private float _gravityForce;

    private CharacterController _characterController;
    public UnityEngine.Object enemyRef;

    




    void Start()
    {
        transform.position = spawnPoint.position;
        _characterController = GetComponent<CharacterController>();
        

    }

   
    void Update()
    {
        if (inFire == false)
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); // ���� ���� �� �������
        }

        




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && nowAttack)
        {
            
            StartCoroutine(PlayerAttack());
           




        }
       
    }

    private void OnTriggerEnter(Collider thisTrigger) // ��� �������� � ������
    {
        if (thisTrigger.gameObject.tag == "Fire")
        {
            anim.SetInteger("StudyAnimaton", 2);
            inFire = true;
            

        }
        
    }
    private void OnTriggerExit(Collider thissTrigger) // ��� ����� �� ������
    {
        if (thissTrigger.gameObject.tag == "Fire")
        {
            anim.SetInteger("StudyAnimaton", 0);
            inFire = false;
        }

    }

    private void GamingGravity()
    {
        _moveVector = Vector3.zero;
        _moveVector.y = _gravityForce;
        if (!_characterController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
        else _gravityForce = -1f;
    }
    IEnumerator PlayerAttack() // �������� 1 ������� ����� ����� �����
    {
        nowAttack = false;
        anim.SetInteger("StudyAnimaton", 1);
        playerHealth.TakeHit(enemyDamage);
        yield return new WaitForSeconds(1f);
        nowAttack = true;
        anim.SetInteger("StudyAnimaton", 0);
    }
}
