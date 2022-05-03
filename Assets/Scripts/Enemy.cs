using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform spawnPoint; // точка респавна зомби
    public GameObject player; // главный герой

    public Health playerHealth; // жизни ГГ

    public Animator anim;

    private Vector3 _moveVector;
    public float speed;

    public float enemyDamage = 1f;

    private bool inFire = false;
    private bool nowAttack = true; // готов ли враг атаковать игрока

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
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); // враг идет за игроком
        }

        




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && nowAttack)
        {
            
            StartCoroutine(PlayerAttack());
           




        }
       
    }

    private void OnTriggerEnter(Collider thisTrigger) // при подхдоде к костру
    {
        if (thisTrigger.gameObject.tag == "Fire")
        {
            anim.SetInteger("StudyAnimaton", 2);
            inFire = true;
            

        }
        
    }
    private void OnTriggerExit(Collider thissTrigger) // при уходе от костра
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
    IEnumerator PlayerAttack() // ожидание 1 секунды после атаки врага
    {
        nowAttack = false;
        anim.SetInteger("StudyAnimaton", 1);
        playerHealth.TakeHit(enemyDamage);
        yield return new WaitForSeconds(1f);
        nowAttack = true;
        anim.SetInteger("StudyAnimaton", 0);
    }
}
