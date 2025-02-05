using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void SwitchSceneClassic()
    {
        SceneManager.LoadScene(2);
    }
    public void SwitchSceneEndless()
    {
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
