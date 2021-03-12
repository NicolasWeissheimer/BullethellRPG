using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public static Weapon weapon;
    public static Armor armor;
    public static Helm helm;
    public static Ring ring;


    public static void EquipMainHand(Weapon newWeapon)
    {
        PlayerAttack.attackProjectile = newWeapon.bullet;
        PlayerAttack.bulletForce = newWeapon.shotSpeed;
        PlayerAttack.bulletLifeTime = newWeapon.shotLifeTime;
        PlayerAttack.weaponWeight = newWeapon.weight;
        PlayerAttack.weaponIntellect = newWeapon.intellect;
        PlayerAttack.weaponDamage = newWeapon.damage + (PlayerStats.attack * 2);

        if (weapon != null)
        {
            PlayerStats.life -= weapon.life;
            PlayerStats.mana -= weapon.mana;
            PlayerStats.stamina -= weapon.stamina;
            PlayerStats.attack -= weapon.attack;
            PlayerStats.dexterity -= weapon.dexterity;
            PlayerStats.faith -= weapon.faith;
            PlayerStats.speed -= weapon.speed;
            PlayerStats.defense -= weapon.defense;
            PlayerStats.vitality -= weapon.vitality;
            PlayerStats.wisdom -= weapon.wisdom;
            PlayerStats.resistance -= weapon.resistance;
        }

        PlayerStats.life += newWeapon.life;
        PlayerStats.mana += newWeapon.mana;
        PlayerStats.stamina += newWeapon.stamina;
        PlayerStats.attack += newWeapon.attack;
        PlayerStats.dexterity += newWeapon.dexterity;
        PlayerStats.faith += newWeapon.faith;
        PlayerStats.speed += newWeapon.speed;
        PlayerStats.defense += newWeapon.defense;
        PlayerStats.vitality += newWeapon.vitality;
        PlayerStats.wisdom += newWeapon.wisdom;
        PlayerStats.resistance += newWeapon.resistance;

        PlayerMovement.SetStats();
        weapon = newWeapon;
    }

    public static void EquipArmor(Armor newArmor)
    {
        if (armor != null)
        {
            PlayerStats.life -= armor.life;
            PlayerStats.mana -= armor.mana;
            PlayerStats.stamina -= armor.stamina;
            PlayerStats.attack -= armor.attack;
            PlayerStats.dexterity -= armor.dexterity;
            PlayerStats.faith -= armor.faith;
            PlayerStats.speed -= armor.speed;
            PlayerStats.defense -= armor.defense;
            PlayerStats.vitality -= armor.vitality;
            PlayerStats.wisdom -= armor.wisdom;
            PlayerStats.resistance -= armor.resistance;
        }

        PlayerStats.life += newArmor.life;
        PlayerStats.mana += newArmor.mana;
        PlayerStats.stamina += newArmor.stamina;
        PlayerStats.attack += newArmor.attack;
        PlayerStats.dexterity += newArmor.dexterity;
        PlayerStats.faith += newArmor.faith;
        PlayerStats.speed += newArmor.speed;
        PlayerStats.defense += newArmor.defense;
        PlayerStats.vitality += newArmor.vitality;
        PlayerStats.wisdom += newArmor.wisdom;
        PlayerStats.resistance += newArmor.resistance;

        PlayerMovement.SetStats();
        armor = newArmor;
    }

    public static void EquipHelm(Helm newHelm)
    {
        if (helm != null)
        {
            PlayerStats.life -= helm.life;
            PlayerStats.mana -= helm.mana;
            PlayerStats.stamina -= helm.stamina;
            PlayerStats.attack -= helm.attack;
            PlayerStats.dexterity -= helm.dexterity;
            PlayerStats.faith -= helm.faith;
            PlayerStats.speed -= helm.speed;
            PlayerStats.defense -= helm.defense;
            PlayerStats.vitality -= helm.vitality;
            PlayerStats.wisdom -= helm.wisdom;
            PlayerStats.resistance -= helm.resistance;
        }

        PlayerStats.life += newHelm.life;
        PlayerStats.mana += newHelm.mana;
        PlayerStats.stamina += newHelm.stamina;
        PlayerStats.attack += newHelm.attack;
        PlayerStats.dexterity += newHelm.dexterity;
        PlayerStats.faith += newHelm.faith;
        PlayerStats.speed += newHelm.speed;
        PlayerStats.defense += newHelm.defense;
        PlayerStats.vitality += newHelm.vitality;
        PlayerStats.wisdom += newHelm.wisdom;
        PlayerStats.resistance += newHelm.resistance;

        PlayerMovement.SetStats();
        helm = newHelm;
    }

    public static void EquipRing(Ring newRing)
    {
        if (ring != null)
        {
            PlayerStats.life -= ring.life;
            PlayerStats.mana -= ring.mana;
            PlayerStats.stamina -= ring.stamina;
            PlayerStats.attack -= ring.attack;
            PlayerStats.dexterity -= ring.dexterity;
            PlayerStats.faith -= ring.faith;
            PlayerStats.speed -= ring.speed;
            PlayerStats.defense -= ring.defense;
            PlayerStats.vitality -= ring.vitality;
            PlayerStats.wisdom -= ring.wisdom;
            PlayerStats.resistance -= ring.resistance;
        }

        PlayerStats.life += newRing.life;
        PlayerStats.mana += newRing.mana;
        PlayerStats.stamina += newRing.stamina;
        PlayerStats.attack += newRing.attack;
        PlayerStats.dexterity += newRing.dexterity;
        PlayerStats.faith += newRing.faith;
        PlayerStats.speed += newRing.speed;
        PlayerStats.defense += newRing.defense;
        PlayerStats.vitality += newRing.vitality;
        PlayerStats.wisdom += newRing.wisdom;
        PlayerStats.resistance += newRing.resistance;

        PlayerMovement.SetStats();
        ring = newRing;
    }

}
