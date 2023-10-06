using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IDamageable
{
    public CharacterSO characterSO;
    public int curHealth;

    int _health;
    int _armor;
    float _speed;
    float _acceleration;

    public int Health { get { return _health; } }
    public int Armor { get { return _armor; } }
    public float Speed { get { return _speed; } }
    public float Acceleration { get { return _acceleration; } }

    private void Start()
    {
        InitCharacterClass();
    }

    //Dynamic setup character after load from menu
    //Call this class from game manager
    public void SetCharacterClass(CharacterSO so)
    {
        characterSO = so;

        _health = so.health;
        _armor = so.armor;
        _speed = so.baseSpeed;
        _acceleration = so.acceleration;
    }

    public void InitCharacterClass()
    {
        _health = characterSO.health;
        _armor = characterSO.armor;
        _speed = characterSO.baseSpeed;
        _acceleration = characterSO.acceleration;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public void Heal(int value)
    {
        //TODO: increase health
    }

    public void TakeDamage(int value)
    {
        //TODO: decrease health
        //TODO: game over when health = 0
    }
}
