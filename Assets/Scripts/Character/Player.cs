using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable
{
    public CharacterSO characterSO;
    public PlayerController playerController;
    public int curHealth;
    Rigidbody2D _rb;

    public float knockbackValue = 2f;
    public float knockbackDis = 2f;

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
        _rb = GetComponent<Rigidbody2D>();
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

        curHealth = _health;
    }

    public void InitCharacterClass()
    {
        _health = characterSO.health;
        _armor = characterSO.armor;
        _speed = characterSO.baseSpeed;
        _acceleration = characterSO.acceleration;

        curHealth = _health;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public void Heal(int value)
    {
        //TODO: increase health
    }

    Vector2 _contactPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Agent")
        {
            ContactPoint2D cPos = collision.contacts[0];
            Vector2 pos = cPos.point;

            Debug.DrawRay(cPos.point, cPos.normal, Color.white);
            //Debug.Break();

            _contactPos = pos;

            _rb.velocity = cPos.normal * knockbackValue;

            TakeDamage(1);
        }
    }

    private void Update()
    {
        float distance = Vector2.Distance(_contactPos, transform.position);

        if (distance > knockbackDis)
        {
            _rb.velocity = Vector2.zero;
            _contactPos = Vector2.zero;
        }
    }

    public void TakeDamage(int value)
    {
        if (_health <= 0)
        {
            _health = 0;
            playerController.enabled = false;
        }

        curHealth -= 1;
    }
}
