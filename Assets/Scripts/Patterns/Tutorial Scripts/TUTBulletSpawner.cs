using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTBulletSpawner : MonoBehaviour
{
    [SerializeField]GameObject BulletPrefab;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
            bullet.GetComponent<BulletMovement>().moveSpeed = 4;
            timer = 0;
        }
    }
}
