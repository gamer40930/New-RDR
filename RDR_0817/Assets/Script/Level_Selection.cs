using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Selection : MonoBehaviour
{
    

    delegate void setButton(int index);
    setButton _setButton;

    public GameObject[] LevelButtons;
    int num;
    
    private void Start()
    {
        
        num = PlayerPrefs.GetInt("openLevel");
        _setButton = UnlockButton; 
        _setButton(num);

        print(PlayerPrefs.GetInt("openLevel"));

    }

    /// <summary>
    /// 開啟下一關
    /// </summary>
    /// <param name="i"></param>
    public  void UnlockButton(int i)
    {
        
        if(LevelButtons[i] != null) 
        {
            LevelButtons[i].GetComponent<LevelButton>().LevelUnlock = true;
            print("開啟關卡:" + i);
        }
        
    }


    public void BackToMenu()
    {
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
    public void GoToLevel_00()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToLevel_01()
    {
        SceneManager.LoadScene(3);
    }

}
