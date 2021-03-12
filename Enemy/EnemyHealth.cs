using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public Slider slider;
    void Start()
    {
        hp = maxHp;
        slider.maxValue = maxHp;
        slider.value = hp;
    }

    private void Update()
    {
        SetBar();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        SetBar();
        if(hp <= 0) { Die(); }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void SetBar()
    {
        slider.maxValue = maxHp;
        slider.value = hp;
    }
}
