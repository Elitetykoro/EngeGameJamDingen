using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    float timer = 0;
    float flickerCooldown = 0;
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;
    Image image;

    private void Start()
    {
        flickerCooldown = Random.Range(5, 10);
        image = GetComponent<Image>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > flickerCooldown)
        {
            flickerCooldown = Random.Range(5, 10);
            timer = 0;
            StartCoroutine(FlickeringLights());
        }
    }
    IEnumerator FlickeringLights()
    {
        image.sprite = offSprite;
        yield return new WaitForSeconds(0.1f);
        image.sprite = onSprite;
    }
}
