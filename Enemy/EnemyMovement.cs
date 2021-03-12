using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float distance;
    public Transform player;
    public bool agro;
    public delegate void Behaviour();
    public Behaviour[] behaviour = new Behaviour[2];
    public int type = 0;

    private void Start()
    {
        behaviour[0] = RunTowardsPlayer;
        behaviour[1] = RunFromPlayer;
    }

    private void FixedUpdate()
    {
        if(agro == true)
        {
            behaviour[type]();
        }
    }

    void RunTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    void RunFromPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -1 * moveSpeed * Time.deltaTime);
    }
}
