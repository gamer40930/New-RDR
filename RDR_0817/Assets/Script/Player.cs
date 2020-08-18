using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    #region 屬性與欄位
    [Header("移動速度"), Range(1, 1000)]
    public float speed = 10;
    [Header("跳躍高度"), Range(1, 5000)]
    public float height;

    [Header("資訊欄")]
    public Text info;
    [Header("資訊欄背景")]
    public GameObject infoBox;

    [Header("動作選單")]
    public GameObject actionMenu;
    [Header("狗大便")]
    public GameObject poo;
    [Header("狗尿")]
    public GameObject pee;

    [Header("飽食度")]
    public Image foodBar;
    [SerializeField, Range(0.1f, 1f)]
    float _foodbar;
    [SerializeField]
    Text foodnum;
    [Header("飽水度")]
    public Image waterBar;
    [SerializeField, Range(0.1f, 1f)]
    float _waterbar;
    [SerializeField]
    Text waternum;


    /// <summary>
    /// 旋轉角度 
    /// </summary>
    private Vector3 angle;  //移動腳色用
    private Rigidbody rig; // 後面在移動、跳躍等動作中使用
    public Animator ani; // 後面控制動畫
    [Header("屁股生成點")]
    public Transform butt;


    /// <summary>
    /// 攝影機
    /// </summary>
    private Transform cam;

    [Header("旋轉"), Range(0, 100)]
    public float turn = 1;


    [Header("選項的圖鑑頁面")]
    public LibaryImageBool libaryImage;



    #endregion



    private void Start()
    {
        waterBar.fillAmount = _waterbar;
        foodBar.fillAmount = _foodbar;

        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        

        libaryImage.collections[0] = true;
    }


    #region 玩家執行動作





    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 執行動畫時候停止移動
        if (ani.GetCurrentAnimatorStateInfo(0).IsTag("Stop")) return;

        #region 移動

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        rig.velocity = (transform.forward * speed * Mathf.Abs(v)) + (transform.forward * speed * Mathf.Abs(h));

        // 走路動畫
        // 動畫.設定布林("DogWalk",布林值) - 當前後取絕對值 大於 0 時勾選
        // DogWalk -> 在Animator 中 Parameters 自訂的 BOOL 選項
        ani.SetBool("Dog_Walk", Mathf.Abs(v) > 0 || Mathf.Abs(h) > 0);

        // 走路音效

        #region 轉向

        // 沿著 Y 軸轉向
        if (v == 1) angle = new Vector3(0, 0, 0);    // 前
        if (v == -1) angle = new Vector3(0, 180, 0); // 後
        if (h == 1) angle = new Vector3(0, 90, 0);   // 右
        if (h == -1) angle = new Vector3(0, 270, 0); // 左

        transform.eulerAngles = angle;

        #endregion


        #endregion
    }

   


    /// <summary>
    /// 搜尋
    /// </summary>
    /// <param name="_trig"></param>     
    public void Search()
    {



        ani.SetTrigger("Dog_Serch");
        // 搜尋 音效


    }

    /// <summary>
    /// 1f後更換訊息欄內容
    /// </summary>
    /// <param name="_info"></param>
    /// <returns></returns>
    public IEnumerator changeInfo(string _info)
    {
        yield return new WaitForSeconds(1f);
        info.text = _info;
        infoBox.SetActive(true);
    }

    public IEnumerator CleanInfo()
    {
        yield return new WaitForSeconds(5f);
        info.text = "";
        infoBox.SetActive(false);
    }

    /// <summary>
    /// 吃道具
    /// </summary>
    public void Eat(float Addfeed)
    {

        ani.SetTrigger("Dog_Eat");
        foodBar.fillAmount += Addfeed;
        // 吃東西音效        
    }

    /// <summary>
    /// 喝水
    /// </summary>
    /// <param name="water"></param>
    public void Drink(float water)
    {


        ani.SetTrigger("Dog_Eat");
        waterBar.fillAmount += water;
        // 喝水音效
    }
    public void Pee()
    {
        actionMenu.SetActive(false);
        if (waterBar.fillAmount >= 0.4)  // 如果飽水度達到 40% 以上
        {

            ani.SetTrigger("Dog_Pee");
            //  尿尿音效
            waterBar.fillAmount -= 0.1f;// 扣飽水度
            Instantiate(pee, butt);
            // 扣飽水量 
        }
        else StartCoroutine(changeInfo("水量不足..."));



    }
    public void Poo()
    {
        actionMenu.SetActive(false);
        if (foodBar.fillAmount >= 0.4)
        {
            // 如果飽食度達到 60% 以上

            ani.SetTrigger("Dog_Poop");
            // 大便音效
            foodBar.fillAmount -= 0.1f;// 扣飽食度
            Instantiate(poo, butt);
        }

        else StartCoroutine(changeInfo("飽食度不足..."));


    }
    public void Pick()
    {
        // 撿取音效
        // 撿取判斷 (是否有東西可以撿取)
        ani.SetTrigger("Dog_Pick");


    }




    #endregion

    #region 事件更新

    // 固定更新頻率事件 : 1 秒 50 禎，使用物理必須在此事件內
    private void FixedUpdate()
    {



        Move();



    }

    private void Update()
    {
        float W = (waterBar.fillAmount) * 100;
        float F = (foodBar.fillAmount) * 100;


        waternum.text = Mathf.Floor(W) + "%";
        foodnum.text = Mathf.Floor(F) + "%";

        // StartCoroutine(CleanInfo());

    }
    #endregion



    /// <summary>
    /// 碰撞事件
    /// </summary>
    /// <param name="hit"></param>
    private void OnCollisionEnter(Collision hit)
    {



        #region 圖鑑判斷

        if (hit.gameObject.name.Contains("Board"))
        {
            libaryImage.collections[1] = true;
        }
        if (hit.gameObject.name.Contains("Bottle_01"))
        {
            libaryImage.collections[2] = true;
        }

        if (hit.gameObject.name.Contains("Bottle_02"))
        {
            libaryImage.collections[3] = true;
        }

        if (hit.gameObject.name.Contains("Box_01"))
        {
            libaryImage.collections[4] = true;
        }

        if (hit.gameObject.name.Contains("Box_02"))
        {
            libaryImage.collections[5] = true;
        }

        if (hit.gameObject.name.Contains("Box_03"))
        {
            libaryImage.collections[6] = true;
        }
        if (hit.gameObject.name.Contains("Cub"))
        {
            libaryImage.collections[7] = true;
        }

        if (hit.gameObject.name.Contains("Crash column"))
        {
            libaryImage.collections[8] = true;
        }
        if (hit.gameObject.name.Contains("fire_hydrant"))
        {
            libaryImage.collections[9] = true;
        }
        if (hit.gameObject.name.Contains("news_paper"))
        {
            libaryImage.collections[10] = true;
        }
        if (hit.gameObject.name.Contains("Paper_01"))
        {
            libaryImage.collections[11] = true;
        }
        if (hit.gameObject.name.Contains("Pizza_01"))
        {
            libaryImage.collections[12] = true;
        }
        if (hit.gameObject.name.Contains("Pizza_box_Close"))
        {
            libaryImage.collections[13] = true;
        }
        if (hit.gameObject.name.Contains("Pizza_box_Open"))
        {
            libaryImage.collections[14] = true;
        }
        if (hit.gameObject.name.Contains("Pizza_small_01"))
        {
            libaryImage.collections[15] = true;
        }
        if (hit.gameObject.name.Contains("Plane"))
        {
            libaryImage.collections[16] = true;
        }
        if (hit.gameObject.name.Contains("plant_Tree"))
        {
            libaryImage.collections[17] = true;
        }
        if (hit.gameObject.name.Contains("Plants_Cactus"))
        {
            libaryImage.collections[18] = true;
        }
        if (hit.gameObject.name.Contains("Road_Closs_Sign"))
        {
            libaryImage.collections[19] = true;
        }
        if (hit.gameObject.name.Contains("Single_cone 2"))
        {
            libaryImage.collections[20] = true;
        }
        if (hit.gameObject.name.Contains("Single_cone 1"))
        {
            libaryImage.collections[21] = true;
        }
        if (hit.gameObject.name.Contains("Street_Lamp"))
        {
            libaryImage.collections[22] = true;
        }
        if (hit.gameObject.name.Contains("Traffic_Light"))
        {
            libaryImage.collections[23] = true;
        }




        #endregion

    }

    private void OnTriggerEnter(Collider hit)
    {
        #region 圖鑑
        if (hit.name.Contains("Flyer_MissingDog"))
        {
            libaryImage.collections[16] = true;
        }
        if (hit.name.Contains("Paper_01"))
        {
            libaryImage.collections[11] = true;
        }

        #endregion
    }

}


