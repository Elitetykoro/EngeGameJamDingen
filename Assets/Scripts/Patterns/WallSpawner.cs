using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]GameObject[] walls;
    float wallTimer;
    GameObject currentwall;
    void Update()
    {
        wallTimer += Time.deltaTime;
        if (wallTimer > UnityEngine.Random.Range(15, 20))
        {
            currentwall = walls[(int)Mathf.Round(UnityEngine.Random.Range(0,1))];
            currentwall.SetActive(true);
            wallTimer = 0;
        }
        if(wallTimer > 3 && currentwall != null)
        {
            currentwall.SetActive(false);
            currentwall = null;
        }
    }
}
