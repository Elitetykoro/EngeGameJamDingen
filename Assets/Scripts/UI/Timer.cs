using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    float timer;
    void Start()
    {
        timer = 0;
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        textMeshPro.text = (Mathf.Round(timer).ToString() + " Seconds");
    }
}
