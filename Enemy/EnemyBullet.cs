using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;
    public float rotation;
    public float lifeTime;
    public int damage;
    public bool pierce;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats.TakeDamage(damage);
            if(pierce == false) { Destroy(gameObject); }
        }

        //else if(collision.tag != "Enemy")
        //{
        //    if (pierce == false) { Destroy(gameObject); }
        //}
    }

    void FixedUpdate()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }
}
