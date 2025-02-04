using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI dialogueText;
    private int characterIndex;
    private float timer = 0;
    private string textDialogue = "";
    float timeBetweenCharaters;
    public void Dialogue(string text, float timeBetweenChar) // Function for use the dialogue 
    {
        dialogueText.text = "";
        textDialogue = text;
        timeBetweenCharaters = timeBetweenChar;
        characterIndex = 0;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenCharaters && characterIndex < textDialogue.ToCharArray().Length) // Split text into characters add 1 character to the dialogtext
        {
            dialogueText.text += textDialogue.ToCharArray()[characterIndex];
            characterIndex++;
            timer = 0;
        }
    }
}