using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreCount : MonoBehaviour
{
    [Header("計分")]
    public float currentScore;
    float totalScore = 100;
    
    [HideInInspector]
    public int intoTriggerboxTime;
    public float finleScore;
    
    public Text Score;
    public Image stars;

    float higherScore;
     Level_Selection _level_Selection;


    int currentSceneIndex;
    int NextLevelIndex; // 關卡選擇頁面的按鈕順序


    private void Start()   
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        NextLevelIndex = (currentSceneIndex - 2) + 1;

        higherScore = PlayerPrefs.GetFloat("關卡最高分" + SceneManager.GetActiveScene().buildIndex);

        //print("場景" +SceneManager.GetActiveScene().buildIndex);
        //print("關卡最高分"+PlayerPrefs.GetFloat("關卡最高分" + SceneManager.GetActiveScene().buildIndex));
        //print("currentSceneIndex:" + currentSceneIndex);
        //print("nextSceneIndex:" + NextLevelIndex);

    }

    #region 計分方式
    //1. 找到搜尋點   20 分  (OK
    //2. 吃到道具     5 分   (OK
    //3. 避開NPC      15 分  
    //4. 到達終點     25 分 

    // 額外分數: 20% 
    //1. 到達其他搜尋點 一個 +5分

    #endregion
    private void Update()
    {
        print("現在分數:" + currentScore);
        Counting();
    }
   
    /// <summary>
    /// 加扣分
    /// </summary>
    /// <param name="addScore"></param>
    public void AddScore(float addScore)
    {
        currentScore += addScore;        
    }

    /// <summary>
    /// 分數計算
    /// </summary>
    void Counting()
    {        
        #region 計算分數
        float starcount = currentScore / totalScore;
        stars.fillAmount = starcount;

        finleScore = starcount;
        print("FinalScore" + finleScore);
        Score.text = currentScore + "%";

        #endregion

        #region 結算分數 & 紀錄分數
      
        if (LevelGoal.goal)  //如果玩家到達終點
        {
            // 紀錄分數  ("關卡分數" + 場景編號)
            PlayerPrefs.SetFloat("關卡分數" + SceneManager.GetActiveScene().buildIndex, finleScore);
            print("關卡最高分" + PlayerPrefs.GetFloat("關卡最高分" + SceneManager.GetActiveScene().buildIndex));
            if (finleScore > higherScore)
            {
                PlayerPrefs.SetFloat("關卡最高分" + SceneManager.GetActiveScene().buildIndex, finleScore);
                print("關卡最高分" + PlayerPrefs.GetFloat("關卡最高分" + SceneManager.GetActiveScene().buildIndex));
            }           
        }
        #endregion

    }

    /// <summary>
    /// 回到主頁面
    /// </summary>
    public void backToLevel()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// 重玩
    /// </summary>
    public void rePlay()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// 下一關
    /// </summary>
    public void nextLevel()
    {
        // 關卡選擇頁面解鎖下一關  => 這個寫法會無法讀到腳本        
        // _level_Selection.UnlockButton(1);


        PlayerPrefs.SetInt("openLevel", NextLevelIndex); // 紀錄開啟的按鈕編號
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    

    
   
}
