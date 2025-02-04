using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    [SerializeField] int health;
    int maxHealth = 3;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> Hearts;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Hearts.Add(transform.GetChild(i).gameObject);
        }
    }
    void Update()
    {
        health = player.GetComponent<PlayerHealth>().playerHealth;

        if (health < maxHealth)
        {
            Hearts[health].SetActive(false);
        }
    }
}
