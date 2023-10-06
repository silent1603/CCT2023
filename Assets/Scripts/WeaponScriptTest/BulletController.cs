using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public float speed;
    public GameObject gun;
    public float maxDistance;
    private Vector2 startPosition;
    public bool shouldDestroy = false;
    void Start()
    {
        startPosition = gun.transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Agent")
        {
            var dmg = collision.gameObject.GetComponent<IDamageable>();
            dmg.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(gun.transform.right * speed * Time.deltaTime);

        float distance = Vector2.Distance(startPosition, transform.position);

        // Kiểm tra nếu khoảng cách vượt quá maxDistance, thì xóa viên đạn
        if (distance > maxDistance)
        {
            if (shouldDestroy == true)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
