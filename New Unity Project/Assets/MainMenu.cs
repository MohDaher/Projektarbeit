using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame2d ()
    {
        SceneManager.LoadScene(1);
    }
    public void HowTo()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
