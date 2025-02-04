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
    [SerializeField] tutorial tutScript;
    [SerializeField] Screenshake screenshake;
    bool hasShook;
    [SerializeField] float damageTime = 3;
    PlayerHealth playerHealth;
    [SerializeField] PlayerHit hit;
    [SerializeField]bool isTUT = false;
    [SerializeField] BossHealthBar bossHealthBar;
    [SerializeField] AudioClip bossRoar;
    AudioSource bossSound;


    private void Start()
    {

        bossSound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        screenshake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Screenshake>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        hit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>();
        bossHealthBar = GameObject.FindGameObjectWithTag("BossHealthBar").GetComponent<BossHealthBar>();
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

        if (countTimer >= damageTime)
        {
            if (!hasShook) 
            {
                if (isTUT)
                {
                    tutScript.hasSurvivedRoar = true;
                }
                screenshake.ScreenShake(.5f, 1f, .5f);
                hasShook = true;
                bossSound.PlayOneShot(bossRoar);
                if (shouldTakeDamage)
                {
                    playerHealth.playerHealth--;
                    hit.currentPlayerState = PlayerHit.PlayerState.Invincible;
                    hit.playSoundEffect();
                }
                else if (!shouldTakeDamage)
                {
                    bossHealthBar.bossHealth -= 20f;
                }
            }
            Destroy(gameObject);
        }
        if (!isTUT)
        {
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
        if (isTUT)
        {
            for (int i = 0; i < patternParts.Length; i++)
            {
                if (countTimer <= 1)
                {
                    patternParts[i].countdownText.text = "10";
                }
                else if (countTimer <= 2 && countTimer >= 1)
                {
                    patternParts[i].countdownText.text = "9";
                }
                else if (countTimer <= 3 && countTimer >= 2)
                {
                    patternParts[i].countdownText.text = "8";
                }
                else if (countTimer <= 4 && countTimer >= 3)
                {
                    patternParts[i].countdownText.text = "7";
                }
                else if (countTimer <= 5 && countTimer >= 4)
                {
                    patternParts[i].countdownText.text = "6";
                }
                else if (countTimer <= 6 && countTimer >= 5)
                {
                    patternParts[i].countdownText.text = "5";
                }
                else if (countTimer <= 7 && countTimer >= 6)
                {
                    patternParts[i].countdownText.text = "4";
                }
                else if (countTimer <= 8 && countTimer >= 7)
                {
                    patternParts[i].countdownText.text = "3";
                }
                else if (countTimer <= 9 && countTimer >= 8)
                {
                    patternParts[i].countdownText.text = "2";
                }else if (countTimer <= 10 && countTimer >= 9)
                {
                    patternParts[i].countdownText.text = "1";
                }
            }
        }
    }

}
