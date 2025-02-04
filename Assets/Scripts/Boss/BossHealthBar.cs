using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthBar : MonoBehaviour
{
    [SerializeField] float maxBossHealth;
    public float bossHealth;
    [SerializeField]Slider healthSlider;
    void Start()
    {
        
        healthSlider.maxValue = maxBossHealth;
        bossHealth = maxBossHealth;
    }

    void FixedUpdate()
    {
        healthSlider.value = bossHealth;
        bossHealth -= Time.deltaTime;
    }
}
