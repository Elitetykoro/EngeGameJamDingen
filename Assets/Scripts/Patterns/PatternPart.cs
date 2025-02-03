using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PatternPart : MonoBehaviour
{
    public bool collidingWithPlayer;
    public TextMeshProUGUI countdownText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!collidingWithPlayer && other.gameObject.CompareTag("Player"))
        {
            collidingWithPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (collidingWithPlayer&&other.gameObject.CompareTag("Player"))
        {
            collidingWithPlayer = false;
        }
    }
}
