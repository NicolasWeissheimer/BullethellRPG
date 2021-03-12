using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float moveSpeed = 2.5f;
    public static float dashSpeed = 0.1f;
    private float currentDashTime;
    private float dashReq;
    public static float startDashTime = 0.15f;
    public Vector2 mouseDirection;
    public bool dashing;
    public Rigidbody2D rb;
    public Vector2 vector;
    public Animator animator;

    public static void SetStats()
    {
        moveSpeed = 2.5f + PlayerStats.speed * 0.02f;
        startDashTime = 0.1f + PlayerStats.speed * 0.001f;
    }
    private void Update()
    {
        vector.x = Input.GetAxis("Horizontal");
        vector.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space") && PlayerStats.stamina > 0)
        {
            dashReq = PlayerStats.maxStamina * (0.5f - (PlayerStats.dexterity * 0.0075f));
            if(dashReq < 10) { dashReq = 10; }
            PlayerStats.stamina -= dashReq;
            dashing = true;
            currentDashTime = startDashTime;
            rb.velocity = Vector2.zero;
            mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2));
        }

        if(dashing == true)
        {
            mouseDirection.x = Mathf.Clamp(mouseDirection.x, -180f, 180f);
            mouseDirection.y = Mathf.Clamp(mouseDirection.y, -180f, 180f);
            rb.velocity = mouseDirection * dashSpeed;
            currentDashTime -= Time.deltaTime;
            if(currentDashTime <= 0)
            {
                rb.velocity = Vector2.zero;
                dashing = false;
            }
        }

        //animator.SetFloat("Horizontal", vector.x);
        //animator.SetFloat("Vertical", vector.y);
        //animator.SetFloat("Speed", vector.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (dashing == false) { rb.MovePosition(rb.position + vector * moveSpeed * Time.fixedDeltaTime); }
    }
}
