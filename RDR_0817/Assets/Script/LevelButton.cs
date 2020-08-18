using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelButton : MonoBehaviour
{
    [Header("未解鎖背景")]
    public Sprite LockImage;
    [Header("解鎖背景")]
    public Sprite UnlockImage;
    [Header("自訂關卡名稱")]
    public string levelName;
    Text LevelTitle;
    [Header("星星圖案")]
    public Image star;
    [Header("鎖的圖案")]
    public GameObject Locker;
    [Header("關卡是否開啟")]
    public  bool LevelUnlock;
    [Header("關卡編號")]
    public int BuildIndex;    
    Image background;

    void Start()
    {
        LevelTitle = gameObject.transform.GetChild(1).GetComponent<Text>();
        background = GetComponent<Image>();

        
    }

   
    void Update()
    {
        if (LevelUnlock == true)
        {
            openLevel();
        }
        else lockLevel();
    }

    /// <summary>
    /// 關卡開啟
    /// </summary>
    void openLevel()
    {
        background.sprite = UnlockImage;
        LevelTitle.text = levelName;
        Locker.SetActive(false);
        gameObject.GetComponent<Button>().interactable = true;
        int index = SceneManager.GetSceneByName(levelName).buildIndex;
        star.fillAmount = PlayerPrefs.GetFloat("關卡最高分" + BuildIndex);
        print("選單頁面關卡最高分" +PlayerPrefs.GetFloat("關卡最高分" + BuildIndex));
    }

    /// <summary>
    /// 關卡關閉
    /// </summary>
    void lockLevel()
    {
        background.sprite = LockImage;
        LevelTitle.text = "? ? ?";
        Locker.SetActive(true);
        star.fillAmount = 0;
        gameObject.GetComponent<Button>().interactable = false;
    }
}
