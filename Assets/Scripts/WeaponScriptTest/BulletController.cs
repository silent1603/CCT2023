using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public GameObject gun;
    public float maxDistance;
    private Vector2 startPosition;
    public bool shouldDestroy = false;
    void Start()
    {
        startPosition = gun.transform.position;
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
