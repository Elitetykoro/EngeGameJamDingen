using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashMultiplier = 2f;
    public float dashDuration = 0.3f;
    private bool isDashing = false;
    private float dashTimer;
    [SerializeField]private Vector3 dashTarget;
    private Rigidbody2D rb;
    Animator animator;
    float horizontalMove, verticalMove;
    [SerializeField] PlayerHit hit;

    void Start()
    {
        animator = GetComponent<Animator>();
        dashTimer = 0;
        rb = GetComponent<Rigidbody2D>();
        hit = GetComponent<PlayerHit>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        if(Mathf.Abs(horizontalMove) >= 0.01|| Mathf.Abs(verticalMove) >= 0.01)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        

        if (Input.GetButtonDown("Dash") && !isDashing && dashTimer >= 3)
        {
            StartDash();
        }
        if(horizontalMove >= 0.001)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }else if(horizontalMove <= -0.001)
        {
            GetComponent<SpriteRenderer>().flipX = true;
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
        hit.currentPlayerState = PlayerHit.PlayerState.Dash;
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
