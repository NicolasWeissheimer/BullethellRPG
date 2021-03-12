using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadius : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && gameObject.CompareTag("Radius"))
        {
            Transform player = collision.GetComponent<Transform>();
            if (enemyMovement != null) { enemyMovement.agro = true; enemyMovement.player = player; }
            if (enemyAttack != null) { enemyAttack.player = collision.GetComponent<Transform>(); enemyAttack.enabled = true; }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.CompareTag("Radius"))
        {
            if (enemyMovement != null) { enemyMovement.agro = false; }
        }
    }
}
