using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speedRotation;
    private Vector3 _moveVector;
    private float _gravityForce;
    

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

        _moveVector.y = _gravityForce;

        _characterController.Move(_moveVector * Time.fixedDeltaTime);
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
        else _gravityForce = -1f;
    }
}
