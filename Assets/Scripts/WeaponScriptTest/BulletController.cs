using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D _rb;
    public int damage;
    public float speed;
    public GameObject gun;
    public float maxDistance;
    private Vector2 startPosition;
    public bool shouldDestroy = false;

    public Vector2 bDir;

    void Start()
    {
        //startPosition = gun.transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Agent")
        {
            var dmg = collision.gameObject.GetComponent<IDamageable>();
            dmg.TakeDamage(damage);
        }
    }
}
