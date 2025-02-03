using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 playerPosition;
    [SerializeField] float moveSpeed;
    void Update()
    {
        playerPosition += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, 0) * Time.deltaTime;
        playerPosition += new Vector3(0, Input.GetAxis("Vertical") * moveSpeed, 0) * Time.deltaTime;

        transform.position = playerPosition;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }
}
