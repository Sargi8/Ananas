using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speedRotation;
    private Vector3 _moveVector;
    private float _gravityForce;
    public float fireWoodQuantity = 0f; // количество дров. Ќе мен€ть!
    public GameObject  FireWood; // сами дрова
    public GameController timer; // врем€ костра.
    public GameObject Bullet;
    public GameObject _spawnBulletPoint;
    public AudioClip _shotAudio;
    public AudioSource _audioSource;
    public ParticleSystem ShotFlash;


    
    


    private CharacterController _characterController;
    private Animator _animator;
    

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        CharacterMove();
        GamingGravity();
    }

    private void Update()
    {

        InputUpdate();

    }

    void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * _moveSpeed;
        _moveVector.z = Input.GetAxis("Vertical") * _moveSpeed;

        if(Vector3.Angle(Vector3.forward, _moveVector)>1f || Vector3.Angle(Vector3.forward,_moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedRotation, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        //анимаци€ движени€
        if (_moveVector.x != 0 || _moveVector.z != 0) _animator.SetBool("Move", true);
        else _animator.SetBool("Move", false);

        _moveVector.y = _gravityForce;

        _characterController.Move(_moveVector * Time.fixedDeltaTime);
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
        else _gravityForce = -1f;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "FireWood") // при соприкосновении с дровами, добавл€етс€ очки дров и удал€етс€ объект.
        {
            fireWoodQuantity++;
            Destroy(collision.gameObject);

        }

    }
    private void OnTriggerEnter(Collider myTrigger)
    {

        if (timer.ckeckFireWoods < fireWoodQuantity && myTrigger.gameObject.tag == "Fire")
        {
            timer._timeLeft += 90f * fireWoodQuantity; // 90 - добавление к таймеру костра. ≈го можно мен€ть.
            timer.ckeckFireWoods = fireWoodQuantity;
            fireWoodQuantity = 0f;

        }
    }

    public void InputUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            _animator.SetBool("Shoot", true);
        }
        else _animator.SetBool("Shoot", false);

        
    }

    public void Shoot()
    {
        Instantiate(Bullet, _spawnBulletPoint.transform.position, transform.rotation);
      //_audioSource.PlayOneShot(_shotAudio);
      ShotFlash.Play();
    }
}
