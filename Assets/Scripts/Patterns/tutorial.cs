using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    float playerHealthCheck;
    DialogueSystem dialogueSystem;
    bool state1, state2, state3, final, doTutorial;
    bool d1, d2, d3, d4, d5, d6, d7;
    [SerializeField] GameObject WASDGraphic, mouseGraphic, tutorialPattern, WASDtutLight, dashTutLight;
    [SerializeField] GameObject bulletSpawner;
    float timer;
    public bool hasMoved, hasMovedToRightSide, hasDashedToRightSide, hasSurvivedRoar;

    bool start;
    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = GetComponent<DialogueSystem>();
        start = true;
        if (PlayerPrefs.GetFloat("hasDoneTutorial") != 1f)
        {
            doTutorial = true;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    void Update()
    {
        if (doTutorial)
        {

            if (start)
            {
                timer += Time.deltaTime;
            }
            if (!d1) dialogueSystem.Dialogue("Use WASD to move", 0.1f); d1 = true;
            if (timer >= 1.6f && !state1 && !state2 && !state3)
            {
                timer = 0;
                start = false;
                WASDGraphic.SetActive(true);
                state1 = true;
            }
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                hasMoved = true;
            }
            if (hasMoved)
            {
                if (!d2) dialogueSystem.Dialogue("Please move into the light", 0.1f); d2 = true;
                WASDtutLight.SetActive(true);
            }
            if (hasMovedToRightSide)
            {
                WASDtutLight.SetActive(false);
                WASDGraphic.SetActive(false);
                start = true;
                bulletSpawner.SetActive(true);
                if (!d3) dialogueSystem.Dialogue("Oh no! looks like some bullets of darkness spawned", 0.05f); d3 = true;
                if (timer >= 5 && !state2 && !state3 && state1)
                {
                    mouseGraphic.SetActive(true);
                    start = false;
                    timer = 0;
                    if (!d4) dialogueSystem.Dialogue("please use the LeftMouseButton to dash to your mouse \n and move into the light", 0.03f); d4 = true;
                    dashTutLight.SetActive(true);
                    state2 = true;
                }
            }
            if (hasDashedToRightSide)
            {
                mouseGraphic.SetActive(false);
                bulletSpawner.SetActive(false);
                dashTutLight.SetActive(false);
                if (!d5) dialogueSystem.Dialogue("Sounds like something is lurking in the dark", 0.05f); d5 = true;
                if (timer >= 3 && !state3 && state2 && state1)
                {
                    start = false;
                    timer = 0;
                    if (!d6) dialogueSystem.Dialogue("Move into the light quickly or you will get hurt", 0.03f); d6 = true;
                    tutorialPattern.SetActive(true);
                    state3 = true;
                }
            }
            if (hasSurvivedRoar)
            {
                Debug.Log(timer);
                start = true;
                if (!d7)
                {
                    timer = 0;
                    dialogueSystem.Dialogue("Goodluck...", 0.5f);
                    d7 = true;
                }
                if (timer >= 5 && !final && state2 && state1 && state3)
                {
                    PlayerPrefs.SetFloat("hasDoneTutorial", 1f);
                    SceneManager.LoadScene(1);
                }
            }
        }

    }
}
