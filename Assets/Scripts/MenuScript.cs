using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // StartGame is a script for the Start button
    public void GoToScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }

    // ExitGame is is a script for the Exit button
    public void ExitGame()
    {
        Application.Quit();
    }


}
