using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
