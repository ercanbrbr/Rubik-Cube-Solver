using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void next()
    {
        if (GameObject.Find("GameController").GetComponent<Game>().isCubeCorrect() == true)
        {
            SceneManager.LoadScene("MainScene");
        }
        
    }
    public void CubeSelect()
    {
        SceneManager.LoadScene("CubeSelect");
    }
    public void closeGame()
    {
        Application.Quit();
    }
}
