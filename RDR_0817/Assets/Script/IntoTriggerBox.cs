using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class IntoTriggerBox : MonoBehaviour
{

    [Header("資訊欄")]
    public Text info;
    [Header("資訊欄背景")]
    public GameObject infoBox;

    [Header("搜尋點是否有東西")]
    public bool YN;
    [Header("生成道具")]
    public GameObject CreatObj;
    [Header("生成道具位置")]
    public Transform CreatPoint;
    [Header("搜尋按鈕")]
    public Button btn;
    [Header("首次分數")]
    public float addpoint;
    [Header("加分")]
    public float bonus;
    [SerializeField]
    private bool hasEnter;  // 玩家是否進入過這個觸發點

    private ScoreCount _scoreCount;
    private Player player;

    private void Start()
    {
        _scoreCount = GameObject.Find("GameManger").GetComponent<ScoreCount>();
        

        if (player == null)
        {

            //player = GameObject.Find("DOG").GetComponent<Player>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    private void Update()
    {


    }

    public void addScore()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DOG") // 如果玩家進入範圍
        {
            infoBox.SetActive(true);
            info.text = "這裡好像有甚麼東西...";
            btn.gameObject.SetActive(true); // 開啟按鈕    

            #region 計分判斷
            if (_scoreCount.intoTriggerboxTime < 1)  // 如果關卡中第一次進入
            {
                print("第一次加分");
                hasEnter = true;
                _scoreCount.AddScore(addpoint);    // 關卡計分 
                _scoreCount.intoTriggerboxTime += 1; // 進入次數
            }

            else if (_scoreCount.intoTriggerboxTime >= 1 & hasEnter == false)
            {
                hasEnter = true;
                print("第二次加分");
                _scoreCount.AddScore(bonus);
            }


            #endregion

            #region 判斷按鈕連結事件
            if (YN == false)
            {
                btn.onClick.AddListener(noObject);
            }
            else
            {
                btn.onClick.AddListener(CreatpProps);
            }
            #endregion
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "DOG")
        {
            info.text = "";
            infoBox.SetActive(false);
            btn.gameObject.SetActive(false);

        }
    }

    /// <summary>
    /// 1f後更換訊息欄內容
    /// </summary>
    /// <param name="_info"></param>
    /// <returns></returns>
    public IEnumerator changeInfo(string _info)
    {
        yield return new WaitForSeconds(0.1f);
        info.text = _info;
        infoBox.SetActive(true);


    }

    public void CleanInfo()
    {

        info.text = "";
        infoBox.SetActive(false);
    }

    /// <summary>
    /// 搜尋點沒有東西
    /// </summary>
    public void noObject()
    {
        player.Search();                                  // 搜尋動畫        
        btn.gameObject.SetActive(false);                   // 關閉按鈕
        StartCoroutine(changeInfo("這裡甚麼都沒有..."));


        Destroy(gameObject, 1f);



    }

    /// <summary>
    /// 生成道具
    /// </summary>
    public void CreatpProps()
    {
         player.Search();                   // 搜尋動畫
        btn.gameObject.SetActive(false);    // 關閉按鈕
        Instantiate(CreatObj, CreatPoint);   // 生成道具
        //生成音效
        StartCoroutine(changeInfo("發現物品!!"));

        Destroy(gameObject, 1f);


    }



}


