using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed;
    float distance;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    Vector3 bossPosition;

    [SerializeField] public BossState currentBossState;
    private void Start()
    {
        bossPosition = transform.position;
    }
    void Update()
    {
        switch (currentBossState)
        {
            case BossState.MoveAroundPlayer:
                transform.rotation = Quaternion.LookRotation(Vector3.forward, player.position - transform.position);
                transform.position = bossPosition;
                distance = (bossPosition - player.position).magnitude;

                if (distance > maxDistance)
                {
                    bossPosition += (player.position - transform.position).normalized * moveSpeed * Time.deltaTime;
                }
                else if (distance < minDistance)
                {
                    bossPosition -= (player.position - transform.position).normalized * moveSpeed * Time.deltaTime;
                }
                if (distance >= minDistance && distance <= maxDistance)
                {
                    bossPosition += transform.right * (moveSpeed / 4) * Time.deltaTime;
                }
                break;
            case BossState.RunAwayFromPlayer:
                transform.position = bossPosition;
                bossPosition -= (player.position - transform.position).normalized * moveSpeed * Time.deltaTime;
                break;
            case BossState.GoToPlayer:
                transform.position = bossPosition;
                bossPosition += (player.position - transform.position).normalized * moveSpeed * Time.deltaTime;
                break;
        }


    }
    
}
public enum BossState
{
    MoveAroundPlayer,
    RunAwayFromPlayer,
    GoToPlayer
}