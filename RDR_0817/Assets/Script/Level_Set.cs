using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

public class Level_Set : MonoBehaviour
{

    public GameObject SetUI;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            
            set();
        }
    }

    /// <summary>
    /// 開啟選單
    /// </summary>
    public void set()
    {

        SetUI.SetActive(!SetUI.activeSelf);

    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Level_Selection()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("離開遊戲");
    }



}
        

    

