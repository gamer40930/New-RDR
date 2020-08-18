using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject LibaryUI;

    public void Level_Selection()
    {
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }

    public void QuickGame()
    {
        Application.Quit();
        Debug.Log("QUIT!!");
    }

    public void BackToMenu()
    {
        LibaryUI.SetActive(false);
    }

    public void OpenLibaryUI()
    {
        LibaryUI.SetActive(true);
    }
}
