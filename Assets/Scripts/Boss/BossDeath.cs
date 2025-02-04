using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    [SerializeField] BossHealthBar bossHealth;
    [SerializeField] BossMovement bossMovement;
    [SerializeField] BossAttack bossAttack;
    AudioSource audioSource;
    [SerializeField] AudioClip monsterScream;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bossMovement = GetComponent<BossMovement>();
        bossAttack = GetComponent<BossAttack>();
    }

    void Update()
    {
        if (bossHealth.bossHealth <= 0)
        {
            audioSource.PlayOneShot(monsterScream);
            StartCoroutine(GoToWinScreen());
        }
    }
    IEnumerator GoToWinScreen()
    {
        bossMovement.enabled = false;
        bossAttack.enabled = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
