using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    public static GameObject attackProjectile;
    public static float bulletForce;
    public static float bulletLifeTime;
    public static int weaponWeight;
    public static int weaponIntellect;
    public static int weaponDamage;
    bool attackable = true;
    public GameObject player;
    public Camera cam;
    public Vector2 mousePos;
    public GameObject[] firePoint;
    public Transform[] attack;
    public Rigidbody2D[] rb;
    private int currentPoint;
    float time = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerStats.stamina > 0 && PlayerStats.mana > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Attack();
        }

        transform.position = player.transform.position;
        firePoint[1].transform.position = attack[1].transform.position;
        firePoint[2].transform.position = attack[2].transform.position;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir1 = mousePos - rb[0].position;
        float angle1 = Mathf.Atan2(lookDir1.y, lookDir1.x) * Mathf.Rad2Deg - 90f;

        Vector2 lookDir2 = mousePos - rb[1].position;
        float angle2 = Mathf.Atan2(lookDir2.y, lookDir2.x) * Mathf.Rad2Deg - 90f;

        Vector2 lookDir3 = mousePos - rb[2].position;
        float angle3 = Mathf.Atan2(lookDir3.y, lookDir3.x) * Mathf.Rad2Deg - 90f;

        rb[0].rotation = angle1;
        rb[1].rotation = angle2;
        rb[2].rotation = angle3;
    }

    public void Attack()
    {
        if(attackable == true && attackProjectile != null)
        {
            attackable = false;
            StartCoroutine(Cooldown());
            PlayerStats.stamina -= weaponWeight;
            PlayerStats.mana -= weaponIntellect;
            GameObject projectile = Instantiate(attackProjectile, firePoint[currentPoint].transform.position, firePoint[currentPoint].transform.rotation * Quaternion.Euler(0f, 0f, 45f));
            projectile.GetComponent<Projectile>().damage = weaponDamage;
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(firePoint[currentPoint].transform.up * bulletForce, ForceMode2D.Impulse);
            currentPoint += 1;
            if(currentPoint == 3) { currentPoint = 1; }
        }
    }

    IEnumerator Cooldown()
    {
        time = 0.75f - PlayerStats.dexterity * 0.02f;
        yield return new WaitForSeconds(time);
        attackable = true;
    }
}
