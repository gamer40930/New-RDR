using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CamerFollow : MonoBehaviour
{

    #region 欄位與屬性
    private Transform Player;
    [Header("開啟時需要鎖定攝影機的UI物件")]
    public GameObject UI0,UI1, UI2, UI3;

    [Header("追蹤速度"), Range(0.1f, 50.5f)]
    public float speed = 1.5f;

    [Header("水平移動速度")]
    public float speedH = 1.5f;   // 水平移動速度
    [Header("垂直移動速度")]
    public float speedV = 1.5f;   // 垂直移動速度

    private float yaw = 0f;     // 水平移動
    private float pitch = 0f;   // 上下移動


    [Header("攝影機")]
    public Transform cam;
    [Header("目標")]
    public Transform target;
    [Header("半徑"), Range(0, 1.5f), Tooltip("半徑不要太大")]
    public float radius = 1;
    [Header("攝影機原始位置")]
    public Vector3 posOriginal;






    #endregion


    #region 事件

    private void Start()
    {
        Player = GameObject.Find("DOG").transform;

        posOriginal = cam.localPosition;  // 取得攝影機原始位置

    }

    private void Update()
    {
        // 選單開啟時不能左右移動攝影機，不然圓形選單方位判斷會跑掉

        if(!UI0.activeSelf && !UI1.activeSelf && !UI2.activeSelf && !UI3.activeSelf)
        {
            CEngles();
        }
        
            
        

    }
    // 延遲更新 : 會在 Update 執行後執行
    // 建議 : 需要追蹤座標要在此事件內
    private void LateUpdate()
    {
        Track();
       


    }

    #endregion

    #region 鏡頭跟隨&控制
    /// <summary>
    /// 追蹤玩家
    /// </summary>
    private void Track()
    {
        // 攝影機與玩家 Y 軸距離   5.5 - 0.47 = 5.03
        // 攝影機與玩家 Z 軸距離   -7 -  0 = -7
        Vector3 posTrack = Player.position;  //設一個 Vector3 posTrack 存放Player的三軸位置資料
        posTrack.y += 2f;                    // 攝影機和玩家 Y軸距離
        posTrack.z += -5f;

        // 攝影機座標 = 變形.座標
        Vector3 posCam = transform.position;

        // Lerp 差值 Mathf.Lerp (A點,B點 百分比);
        // 插值 - 按照百分比取得從一個值過度到另外一個值的中間值
        posCam = Vector3.Lerp(posCam, posTrack, 0.5f * speed * Time.deltaTime);

        //變形.座標 = 攝影機位置
        transform.position = posCam;

    }

    /// <summary>
    /// 追蹤滑鼠角度
    /// </summary>
    private void CEngles()
    {
        yaw += speedH * Input.GetAxis("Mouse X");    // yaw  (水平移動) =  速度H * 滑鼠X軸向
        yaw = Mathf.Clamp(yaw, -90f, 90f);            // 限制 yaw 角度

        pitch -= speedV * Input.GetAxis("Mouse Y");   // pitch(上下移動) =  速度V * 滑鼠Y軸向
        pitch = Mathf.Clamp(pitch, -15f, 15f);        // 限制 pitch 角度 */

        transform.eulerAngles = new Vector3(pitch, yaw, 0);

        //transform.localRotation = Quaternion.Euler(pitch ,yaw, transform.localRotation.z);


    }

    

    #endregion
}
