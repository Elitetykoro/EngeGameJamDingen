using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotLightShow : MonoBehaviour
{
    private Light2D spotLight;
    [SerializeField] Color lightColor;
    void Start()
    {
        spotLight = GetComponent<Light2D>();
        GetComponent<Light2D>().pointLightInnerRadius = transform.GetComponentInParent<CircleCollider2D>().radius;
        GetComponent<Light2D>().pointLightOuterRadius = transform.GetComponentInParent<CircleCollider2D>().radius + 0.5f;
        lightColor += new Color(0, 0, 0, 1);
        spotLight.color = lightColor;
    }
}
