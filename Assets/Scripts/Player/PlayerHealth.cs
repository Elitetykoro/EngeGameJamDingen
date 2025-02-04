using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 5;
    public void TakeDamage()
    {
        playerHealth--;
    }
}
