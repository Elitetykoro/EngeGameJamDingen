using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class PatternScript : MonoBehaviour
{
    public PatternPart[] patternParts;
    [SerializeField]private bool shouldTakeDamage = true;
    private PatternPart collidingWithPlayerPart;
    float countTimer;
    [SerializeField]float duration;
    [SerializeField] float lightFloat;
    [SerializeField] Screenshake screenshake;
    bool hasShook;
    PlayerHealth playerHealth;
    [SerializeField] PlayerHit hit;
    

    private void Start()
    {
        screenshake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Screenshake>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        hit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>();
        patternParts = transform.GetComponentsInChildren<PatternPart>();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < patternParts.Length; i++)
        {
            if (patternParts[i].collidingWithPlayer)
            {
                shouldTakeDamage = false;
                collidingWithPlayerPart = patternParts[i];
            }
        }
        if (collidingWithPlayerPart != null&& !collidingWithPlayerPart.collidingWithPlayer)
        {
            shouldTakeDamage=true;
        }
        countTimer += Time.deltaTime;
            foreach (PatternPart part in patternParts)
            {
                Light2D partLight = part.gameObject.transform.GetChild(0).GetComponent<Light2D>();
                lightFloat = Mathf.Lerp(partLight.pointLightInnerRadius, 0, countTimer / duration);
                partLight.pointLightInnerRadius = lightFloat;
            }

        if (countTimer >= 3)
        {
            Debug.Log("ahhhhhhhh");
            if (!hasShook) 
            {
                screenshake.ScreenShake(.5f, 1f, .5f);
                hasShook = true;
                if (shouldTakeDamage)
                {
                    playerHealth.playerHealth--;
                    hit.currentPlayerState = PlayerHit.PlayerState.Invincible;
                    hit.playSoundEffect();
                }
            }
            Destroy(gameObject);
        }
        for (int i = 0; i < patternParts.Length; i++)
        {
            if (countTimer <= 1)
            {
                patternParts[i].countdownText.text = "3";
            }
            else if (countTimer <= 2 && countTimer >= 1)
            {
                patternParts[i].countdownText.text = "2";
            }
            else if (countTimer <= 3 && countTimer >= 2)
            {
                patternParts[i].countdownText.text = "1";
            }
        }
    }
    
}
