using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireWood : MonoBehaviour
{
    public GameObject FireWood;
    
    void Start()
    {
        Instantiate(FireWood,gameObject.transform);
        
    }

    
}
