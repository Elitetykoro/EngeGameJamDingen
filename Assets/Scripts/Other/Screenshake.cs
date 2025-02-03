using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    private float shakeDuration;
    private float dampingSpeed;
    private float shakeMagnitude;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = originalPosition;
        }
    }
    public void ScreenShake(float duration, float speed, float magnitude)
    {
        shakeDuration = duration;
        dampingSpeed = speed;
        shakeMagnitude = magnitude;
    }
}
