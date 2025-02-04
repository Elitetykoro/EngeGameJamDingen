using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WompWOmp : MonoBehaviour
{
    DialogueSystem dialogueSystem;
    void Start()
    {
        dialogueSystem = GetComponent<DialogueSystem>();
        dialogueSystem.Dialogue("Darkness wins once again...", 0.1f);
    }
    private void Update()
    {


        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }
}
