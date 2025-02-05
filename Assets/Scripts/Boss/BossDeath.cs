using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    [SerializeField] BossHealthBar bossHealth;
    [SerializeField] BossMovement bossMovement;
    [SerializeField] BossAttack bossAttack;
    [SerializeField] AudioClip monsterScream;
    AudioSource audioSource;

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
            StartCoroutine(GoToWinScreen());
            transform.Rotate(0, 0, 580 * Time.deltaTime);
        }
    }
    IEnumerator GoToWinScreen()
    {
        audioSource.PlayOneShot(monsterScream);
        bossMovement.enabled = false;
        bossAttack.enabled = false;
        transform.position = Vector3.zero;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(4);
    }
}
