using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerState currentPlayerState;
    BoxCollider2D playerCollision;
    SpriteRenderer playerRenderer;
    float timer = 0;
    [SerializeField] float invincibleDuration;
    [SerializeField] List<AudioClip> audioClips;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        playerCollision = GetComponent<BoxCollider2D>();
        playerRenderer = GetComponent<SpriteRenderer>();

        if(timer > invincibleDuration)
        {
            currentPlayerState = PlayerState.Hitable;
            timer = 0;
        }

        switch (currentPlayerState)
        {
            case PlayerState.Invincible:
                    timer += Time.deltaTime;
                    playerCollision.enabled = false;
                    playerRenderer.color = new Color(playerRenderer.color.r, playerRenderer.color.g, playerRenderer.color.b, playerRenderer.color.a - (Time.deltaTime * 5));
                    if (playerRenderer.color.a <= 0) playerRenderer.color = new Color(playerRenderer.color.r, playerRenderer.color.g, playerRenderer.color.b, 1);
                    break;
            case PlayerState.Hitable:
                playerCollision.enabled = true;
                playerRenderer.color = new Color(1,1,1,1);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            currentPlayerState = PlayerState.Invincible;
            playSoundEffect();
            transform.GetComponent<PlayerHealth>().playerHealth--;
            Camera.main.GetComponent<Screenshake>().ScreenShake(0.01f, 0.2f, 0.08f);
        }
    }
    public void playSoundEffect()
    {
        audioSource.clip = audioClips[Random.Range(1, 4)];
        audioSource.Play();
    }
    public enum PlayerState
    {
        Invincible,
        Hitable
    }
}
