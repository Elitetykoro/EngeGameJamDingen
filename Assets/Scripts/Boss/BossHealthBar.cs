using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public float bossHealth;
    void Start()
    {
        bossHealth = 200;
    }

    void FixedUpdate()
    {
        bossHealth -= Time.deltaTime;
    }
}
