using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject bossBullet;
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] Transform firePoint3;

    [SerializeField] float attackCooldown = 0;
    [SerializeField] float maxAttackTime = 3;

    [SerializeField] int randomAttack;
    private void Start()
    {
        randomAttack = 1;
    }
    void Update()
    {
        attackCooldown += Time.deltaTime;

        if (attackCooldown > maxAttackTime)
        {
            if (randomAttack == 1)
            {
                randomAttack = Random.Range(1,4);
                StartCoroutine(TripleBulletAttack());
            }
            else if (randomAttack == 2)
            { 
                randomAttack = Random.Range(1, 4);
                StartCoroutine(BulletAttackAfterTime());
            }
            else if (randomAttack == 3)
            {
                randomAttack = Random.Range(1, 4);
                StartCoroutine(MachineGunFromPoint1());
            }
            else if (randomAttack == 4)
            {
                randomAttack = Random.Range(1, 4);
                StartCoroutine(MachineGunFromSidePoints());
            }
            maxAttackTime = Random.Range(1, 4);
            attackCooldown = 0;
        }
    }
    IEnumerator TripleBulletAttack()
    {
        Instantiate(bossBullet,firePoint1.position,transform.rotation);
        Instantiate(bossBullet, firePoint2.position, transform.rotation);
        Instantiate(bossBullet, firePoint3.position, transform.rotation);
        yield return null;
    }
    IEnumerator BulletAttackAfterTime()
    {
        Instantiate(bossBullet, firePoint1.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bossBullet, firePoint2.position, transform.rotation);
        Instantiate(bossBullet, firePoint3.position, transform.rotation);
    }
    IEnumerator MachineGunFromPoint1()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(bossBullet, firePoint1.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator MachineGunFromSidePoints()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(bossBullet, firePoint2.position, transform.rotation);
            Instantiate(bossBullet, firePoint3.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator TripleTripleBullet()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bossBullet, firePoint1.position, transform.rotation);
            Instantiate(bossBullet, firePoint2.position, transform.rotation);
            Instantiate(bossBullet, firePoint3.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
