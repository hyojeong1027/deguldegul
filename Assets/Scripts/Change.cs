using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
