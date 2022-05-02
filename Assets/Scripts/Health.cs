using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float _health;
    public float _maxHealth;

    public void TakeHit(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(float bonusHealth)
    {
        _health += bonusHealth;

        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}
