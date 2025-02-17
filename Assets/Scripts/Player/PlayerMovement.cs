using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float dashMultiplier = 2f;
    [SerializeField] float dashDuration = 0.2f;
    private bool isDashing = false;
    private float dashTimer;
    [SerializeField]private Vector3 dashTarget;
    private Rigidbody2D rb;
    Animator animator;
    float horizontalMove, verticalMove;
    [SerializeField] Slider cooldownSlider;
    Vector3 playerPosition;
    PlayerHit hit;
    AudioSource audioSource;
    [SerializeField] AudioClip dashCharge;
    bool hasPlayed = false;
    

    void Start()
    {
        hit = GetComponent<PlayerHit>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        dashTimer = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = playerPosition;
        playerPosition.x = Mathf.Clamp(transform.position.x, -9, 9);
        playerPosition.y = Mathf.Clamp(transform.position.y, -5, 5);
        

        cooldownSlider.value = dashTimer;
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
        
        if(dashTimer > 3)
        {
            dashTimer = 3;
            if (!hasPlayed)
            {
                audioSource.PlayOneShot(dashCharge);
                hasPlayed = true;
            }
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
            playerPosition = Vector3.MoveTowards(transform.position, dashTarget, step);
        }
        else
        {
            dashTimer += Time.deltaTime;
            HandleMovement();
        }
        
        
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
        hasPlayed = false;
        isDashing = false;
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        playerPosition += new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
    }
}
