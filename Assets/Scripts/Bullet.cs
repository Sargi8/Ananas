using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    Vector3 _lastPos;

    // Start is called before the first frame update
    void Start()
    {
        _lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        RaycastHit hit;
        Destroy(gameObject, 6f);

        Debug.DrawLine(_lastPos, transform.position);
        if(Physics.Linecast(_lastPos, transform.position, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }
            
            Destroy(gameObject);
        }
        _lastPos = transform.position;
    }
}
