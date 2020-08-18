using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

    public static PlayerData data; // 要儲存的資料
    public static bool load;       //紀錄玩家是否選擇讀取模式

    private void Awake()
    {
        DataWrite();
    }
    private void Start()
    {

        if (load) { DataRead(); }
    }

    ///// <summary>
    ///// 選單-新冒險
    ///// </summary>
    //public void NewGame()
    //{
    //    load = false; // 不讀取舊檔
    //    SceneManager.LoadScene(2);
    //}

    /// <summary>
    /// 選單-讀取
    /// </summary>
    public void LoadGame()
    {
        load = true; // 讀取檔案
        SceneManager.LoadScene(2);

    }

    /// <summary>
    /// 存檔
    /// </summary>
    public void SaveGame()
    {
        // 按下存檔 呼叫資料寫入
        DataWrite();
    }

    /// <summary>
    /// 回選單
    /// </summary>
    public void BackToMenu()
    {

    }

    /// <summary>
    /// 資料讀取
    /// </summary>
    public void DataRead()
    {
        print("讀取");

        // 1.取得
        string json = PlayerPrefs.GetString("儲存資料1");

        // 2.JSON 轉為資料類型
        data = JsonUtility.FromJson<PlayerData>(json);

        // 3.取得要寫入資料的物件
        // 玩家位置 = 紀錄點的位置 
        Transform target = GameObject.Find("DOG").transform.transform;
        
        // 4.讀取資料
        target.position = data.pos;
        target.eulerAngles = data.rot;

       
    }

    /// <summary>
    /// 資料寫入
    /// </summary>
    public void DataWrite()
    {
        print("存檔");
        // 1. 取得要寫入資料的物件
        Transform target = GameObject.Find("LoadPoint_01").transform.transform;

        // 2. 寫入資料
        data.pos = target.position;
        data.rot = target.eulerAngles;

        // 3. 轉為JSON
        string json = JsonUtility.ToJson(data);

        // 4. 儲存
        PlayerPrefs.SetString("儲存資料1", json);



    }
}
