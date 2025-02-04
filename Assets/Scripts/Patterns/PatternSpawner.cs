using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{
    float timer, difficultyTimer;
    float previousRandomPattern;
    bool stage1, stage2;
    [SerializeField] float timeBetweenPatterns;
    [SerializeField] GameObject[] patterns;

    void Update()
    {
        
        timer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;
        if (timer > timeBetweenPatterns)
        {
            timer = 0;
            float randomPattern = UnityEngine.Random.Range(0, patterns.Length - 1);
            if(randomPattern == previousRandomPattern)
            {
                randomPattern = UnityEngine.Random.Range(0, patterns.Length - 1);
            }
            Instantiate(patterns[(int)randomPattern]);
            previousRandomPattern = randomPattern;
        }
        if(difficultyTimer >= 90&&!stage1&&!stage2||difficultyTimer >= 120 && stage1 && !stage2)
        {
            if (!stage1 && !stage2)
            {
                stage1 = true;
                timeBetweenPatterns -= 0.5f;
            }else if (stage1 && !stage2)
            {
                stage2 = true;
                timeBetweenPatterns -= 0.5f;
            }
        }
    }
}
