using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashMultiplier = 2f;
    public float dashDuration = 0.5f;
    private bool isDashing = false;
    [SerializeField]private Vector3 dashTarget;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Dash") && !isDashing)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            float step = speed * dashMultiplier * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, dashTarget, step);
        }
        else
        {
            HandleMovement();
        }
        dashTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
        
    }

    void StartDash()
    {
        isDashing = true;
        ;
         // Ensure the player doesn't move on the Z-axis
        StartCoroutine(EndDash());
    }

    IEnumerator EndDash()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
