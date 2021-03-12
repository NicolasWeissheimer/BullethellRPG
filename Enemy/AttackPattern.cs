using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPattern", menuName = "Enemy/AttackPattern")]
public class AttackPattern : ScriptableObject
{
    [Header("Stats")]
    public int damage;
    public float speed;
    public float lifeTime;
    public GameObject bullet;
    public int numberBullets;
    public float minDelay;
    public float maxDelay;
    public float minRotation;
    public float maxRotation;
    public bool pierce;
    public bool isRandom;
    [Header("FollowPlayer")]
    public float followSpeed;
    [Header("Spiral")]
    public float spiralSpeed;
    public int spiralDuration;
    public Vector3 spiralDirection;
}
