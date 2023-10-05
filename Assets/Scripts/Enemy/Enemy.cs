using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class Enemy : MonoBehaviour, IDamageable
{
    public EnemySO enemySO;
    public int curHealth;

    int _health;
    int _armor;
    float _speed;
    float _acceleration;

    private void Start()
    {
        curHealth = 3;
    }

    public void InitCharacterClass()
    {
        //TODO: init enemy data
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public void Heal(float value)
    {
        
    }

    public void TakeDamage(float value)
    {
        if(curHealth <= 0) Destroy(gameObject);

        curHealth--;
    }
}
