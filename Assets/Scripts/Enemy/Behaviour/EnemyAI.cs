using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public EnemySO enemySO;
    Transform _player;
    Rigidbody2D _rb;

    #region STAT
    int _health;
    int _speed;

    #endregion STAT

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f, attackDelay = 1f;

    [SerializeField]
    private float attackDistance = 0.5f;

    //Inputs sent from the Enemy AI to the Enemy controller
    public UnityEvent OnAttack;
    public UnityEvent<Vector2> OnMovement, OnPointer;

    [SerializeField]
    private Vector2 movementInput;

    bool following = false;

    private void Start()
    {
        //Detecting Player and Obstacles around
        Init();
        //InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();

        _health = enemySO.health;
        _speed = enemySO.baseSpeed;

        _player = AIDirector.Instance.player;
    }

    private void Update()
    {
        Vector3 dir = _player.position - transform.position;
        dir = dir.normalized;

        if (Vector2.Distance(_player.position, transform.position) > 1.0f)
        {
            //transform.position += (displacement * _speed * Time.deltaTime);
            _rb.velocity = dir * _speed;
        }
        else
        {
            //do whatever the enemy has to do with the player
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Heal(int value)
    {
        //TODO: maybe regain health?
    }

    public void TakeDamage(int value)
    {
        print("damage = " + value);

        if (_health <= 0)
        {
            //TODO: unsub from update behaviour event
            //TODO: call to the AIDirector to remove self from the list.

            _health = 0;
            Destroy(gameObject);
        }

        _health -= value;
    }
}
