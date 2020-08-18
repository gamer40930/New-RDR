using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CircleMenu : MonoBehaviour
{
    #region 欄位與屬性
    private Vector2 mousePos; 
    private float currentAngle; // 計算角度用
    private int segment;        // 圓形等分
        
    [Header ("按鈕圖片")]
    public Image[] options;
    [Header("按鈕顏色")]
    public Color normalColor, hightlightColor;
    [Header("圓形選單")]
    public GameObject circleM;

    


    /// <summary>
    /// 狗要執行的動作
    /// </summary>
    private Player dogAct;   // 使用Player的腳本
    [Header("狗狗物件")]
    public GameObject dog_;

    #endregion

    private void Start()
    {
        // 抓取 DOG 身上的腳本，這邊沒有在抓一次會找不到腳本          
        dogAct = dog_.GetComponent < Player> ();
     
    }

    void Update()
    {

        #region 設定選取範圍

        // 置中滑鼠位置
        mousePos = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(mousePos.y, mousePos.x)*Mathf .Rad2Deg; // 取得弧度並換算成角度m
        currentAngle = (currentAngle + 360) % 360;                         // 角度定成 0~180 
        segment = (int)currentAngle / 60;

        #endregion

        #region 判斷選取範圍        

        for (int i =0; i<options .Length; i++) // 0 ~ 5 ( 0.1.2.3.4.5)
        {
            if (i == segment)
            {
                options[i].color = hightlightColor;                
            }
            else { options[i].color = normalColor; }
        }

        #endregion

        #region 按鈕觸發動作
        if (Input.GetMouseButtonDown(0))
        {
            
            switch (segment)
            {
                case 0:
                    dogAct.Pick();
                break;

                case 1:
                    dogAct.Eat(0);
                    break;

                case 2:
                    dogAct.Search();
                    break;

                case 3:
                    dogAct.Pee();
                    break;

                case 4:
                    dogAct.Poo ();
                    break;

            }
            
            circleM.SetActive (false);
            
        }

        

        #endregion
    
    }
}
