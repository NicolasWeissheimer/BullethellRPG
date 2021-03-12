using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float[] followSpeed;
    public float distance;
    int index;

    private void FixedUpdate()
    {
        RunTowardsPlayer();
        followSpeed[0] = PlayerMovement.moveSpeed * 1.1f;
        followSpeed[1] = PlayerMovement.moveSpeed * 3;
    }

    void RunTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed[index] * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.transform.position) > 3f)
        {
            index = 1;
        }

        else if(Vector2.Distance(transform.position, player.transform.position) < 1.2f)
        {
            index = 0;
        }
    }
}
