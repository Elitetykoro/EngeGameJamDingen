using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashMultiplier = 2f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    private float dashTimer;
    [SerializeField]private Vector3 dashTarget;
    private Rigidbody2D rb;

    void Start()
    {
        dashTimer = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && dashTimer >= 3)
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
            dashTimer += Time.deltaTime;
            HandleMovement();
        }
        //dashTarget = ;
        
    }

    void StartDash()
    {
        isDashing = true;
        dashTarget = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        StartCoroutine(EndDash());
    }

    IEnumerator EndDash()
    {
        yield return new WaitForSeconds(dashDuration);
        dashTimer = 0;
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
