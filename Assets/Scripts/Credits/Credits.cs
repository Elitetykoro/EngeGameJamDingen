using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    Vector3 scrollPosition;
    private void Start()
    {
        scrollPosition = transform.position;
    }
    void Update()
    {
        transform.position = scrollPosition;
        scrollPosition += new Vector3(0, 1, 0) * 50 * Time.deltaTime;
        scrollPosition.y = Mathf.Clamp(scrollPosition.y, -1080, 1620);

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
