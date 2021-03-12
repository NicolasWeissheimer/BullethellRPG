using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Basics")]
    Rigidbody2D rb;
    public Transform enemy;
    public Transform player;
    [Header("Patterns")]
    public AttackPattern[] attackPatterns = new AttackPattern[50];
    public int patternIndex;
    public int movementIndex;
    public int spiralDuration;
    public bool randomAttack;
    delegate void AttackType();
    AttackType[] attackType = new AttackType[3];
    Vector2 bulletVelocity = new Vector2(1, 0);
    float timer;
    public float[] rotations;

    private void Start()
    {
        attackType[0] = FollowPlayer;
        attackType[1] = Spiral;
        attackType[2] = Freeze;

        rb = GetComponent<Rigidbody2D>();
        timer = Random.Range(attackPatterns[patternIndex].minDelay, attackPatterns[patternIndex].maxDelay);
        rotations = new float[attackPatterns[patternIndex].numberBullets];
        spiralDuration = attackPatterns[patternIndex].spiralDuration;
    }

    void ChangePattern()
    {
        patternIndex++;
        if(patternIndex == attackPatterns.Length) { patternIndex = 0; }
        spiralDuration = attackPatterns[patternIndex].spiralDuration;
        int bullets = attackPatterns[patternIndex].numberBullets;
        rotations = new float[bullets];
    }

    private void Update()
    {
        if(attackType != null) { attackType[movementIndex](); }

        if(timer <= 0)
        {
            spiralDuration--;
            if(spiralDuration <= 0) { ChangePattern(); }
            Shoot();

            timer = Random.Range(attackPatterns[patternIndex].minDelay, attackPatterns[patternIndex].maxDelay);
        }

        transform.position = enemy.position;

        timer -= Time.deltaTime;
    }
    GameObject[] Shoot()
    {
        if(attackPatterns[patternIndex].isRandom == true)
        {
            RandomRotation();
        }

        else
        {
            DistributedRotations();
        }

        GameObject[] spawnedBullets = new GameObject[attackPatterns[patternIndex].numberBullets];

        for (int i = 0; i < attackPatterns[patternIndex].numberBullets; i++)
        {
            spawnedBullets[i] = Instantiate(attackPatterns[patternIndex].bullet, transform);
            var b = spawnedBullets[i].GetComponent<EnemyBullet>();
            b.rotation = rotations[i];
            b.speed = attackPatterns[patternIndex].speed;
            b.lifeTime = attackPatterns[patternIndex].lifeTime;
            b.damage = attackPatterns[patternIndex].damage;
            b.pierce = attackPatterns[patternIndex].pierce;
            b.velocity = bulletVelocity;
            spawnedBullets[i].transform.SetParent(null, true);
            b.rotation += transform.eulerAngles.z;
        }

        return spawnedBullets;
    }

    public float[] RandomRotation()
    {
        for(int i = 0; i < attackPatterns[patternIndex].numberBullets; i++)
        {
            rotations[i] = Random.Range(attackPatterns[patternIndex].minRotation, attackPatterns[patternIndex].maxRotation);
        }

        return rotations;
    }
    
    public float[] DistributedRotations()
    {
        for (int i = 0; i < attackPatterns[patternIndex].numberBullets; i++)
        {
            var fraction = (float)i / (float)attackPatterns[patternIndex].numberBullets;
            var difference = attackPatterns[patternIndex].maxRotation - attackPatterns[patternIndex].minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + attackPatterns[patternIndex].minRotation;
        }

        return rotations;
    }

    void FollowPlayer()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, attackPatterns[patternIndex].followSpeed * Time.deltaTime);
    }

    void Spiral()
    {
        transform.Rotate(attackPatterns[patternIndex].spiralDirection * attackPatterns[patternIndex].spiralSpeed * Time.deltaTime);
    }

    void Freeze()
    {
        transform.rotation = Quaternion.identity;
    }
}
