using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZone : MonoBehaviour
{
    [SerializeField]bool isWASDtut;
    [SerializeField] tutorial tutScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isWASDtut)
            {
                tutScript.hasMovedToRightSide = true;
            }
            else
            {
                tutScript.hasDashedToRightSide = true;
            }
        }
    }
}
