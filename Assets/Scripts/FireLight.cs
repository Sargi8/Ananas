using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public GameController _timer;
    public GameObject _light;

   
    void Update()
    {
        if (_timer._timeLeft  <= 60f) // ����� ������ ����������� ������
        {
            _light.GetComponent<Light>().range = 4f;
            _light.GetComponent<SphereCollider>().radius = 2f;


        }
        else if (_timer._timeLeft <= 180f) // ����� 3 ����� ����������� ������
        {
            _light.GetComponent<Light>().range = 10f;
            _light.GetComponent<SphereCollider>().radius = 4f;

        } 
        else
        {
            _light.GetComponent<Light>().range = 25f;
            _light.GetComponent<SphereCollider>().radius = 7f;

        }
        
    }
}
