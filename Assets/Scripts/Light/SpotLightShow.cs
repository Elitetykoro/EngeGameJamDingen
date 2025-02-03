using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotLightShow : MonoBehaviour
{
    private Light2D spotLight;
    void Start()
    {
        spotLight = GetComponent<Light2D>();
    }

    void Update()
    {
        GetComponent<Light2D>().pointLightInnerRadius = transform.GetComponentInParent<CircleCollider2D>().radius;
        GetComponent<Light2D>().pointLightOuterRadius = transform.GetComponentInParent<CircleCollider2D>().radius + 0.5f;

        spotLight.color = new Color(0.4f, 0.4f, 0.2f, 1);
    }
}
