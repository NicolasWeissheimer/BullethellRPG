using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public int maxHp;
    [HideInInspector]
    public int hp;
    public Slider slider;
    public float moveSpeed;
    public float distance;
    [HideInInspector]
    public Transform destination;
    public GameObject player;
    public GameObject enemyAttack;

    private void Start()
    {
        hp = maxHp;
        SetBar();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        SetBar();
        if (hp <= 0) { Die(); }
        OnDamageTaken();
    }

    public virtual void OnDamageTaken()
    {

    }

    void Die()
    {
        if(TryGetComponent(out DropLoot drop))
        {
            drop.Drop();
        }
        Destroy(gameObject);
    }

    void SetBar()
    {
        slider.maxValue = maxHp;
        slider.value = hp;
    }
}
