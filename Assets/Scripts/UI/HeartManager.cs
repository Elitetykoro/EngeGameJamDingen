using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth = 3;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> Hearts;
    [SerializeField] Sprite emptyHeart;
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

        if (health < maxHealth && health >= 0)
        {
            Hearts[health].GetComponent<Image>().sprite = emptyHeart;
        }
        if(health <= 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Hearts[i].GetComponent<Image>().sprite = emptyHeart;
            }
        }
    }
}
