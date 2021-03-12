using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float maxLife = 100;
    public static float life = maxLife;
    public static float maxStamina = 50;
    public static float stamina = maxStamina;
    public static float maxMana = 25;
    public static float mana = maxMana;
    public static int attack = 5;
    public static int faith = 5;
    public static int dexterity = 5;
    public static int speed = 5;
    public static int defense = 5;
    public static int vitality = 5;
    public static int wisdom = 5;
    public static int resistance = 5;
    public static int bounty;
    public static int fame;
    public static int honour;
    public static int fameType;

    private void FixedUpdate()
    {
        if(stamina < maxStamina)
        {
            stamina += (resistance * 0.25f) / 15;
        }

        if (mana < maxMana)
        {
            mana += (wisdom * 0.25f) / 20;
        }

        if (life < maxLife)
        {
            life += (vitality * 0.25f) / 30;
        }
    }

    public static void TakeDamage(float damage)
    {
        damage -= defense;
        if(damage < 0) { damage = 0; }
        life -= damage;
    }
}
