using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 5;
    public void TakeDamage()
    {
        playerHealth--;
    }
    private void Update()
    {
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
}
