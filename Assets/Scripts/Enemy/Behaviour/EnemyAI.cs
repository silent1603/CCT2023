using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public EnemySO enemySO;
    Transform _player;
    Rigidbody2D _rb;
    public LayerMask playerLayer;

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

    [SerializeField]
    private Vector2 movementInput;

    bool following = false;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();

        _health = enemySO.health;
        _speed = enemySO.baseSpeed;

        _player = AIDirector.Instance.player;
    }

    private void FixedUpdate()
    {
        Vector3 dir = _player.position - transform.position;
        dir = dir.normalized;

        if (Vector2.Distance(_player.position, transform.position) > attackDistance)
        {
            _rb.velocity = dir * _speed;
        }
        else
        {
            StartCoroutine(AttackPlayer());
        }
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(attackDelay);

        print("Enemy attack");
        var attackPlayer = Physics2D.OverlapCircle(_player.position, attackDistance, playerLayer);
        if (attackPlayer != null)
        {
            var damage = attackPlayer.GetComponent<IDamageable>();
            damage.TakeDamage(1);
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
