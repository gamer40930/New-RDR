using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Image thirstBar;
    public Image hungerBar;


    #region 生成汽車
    [Header ("汽車物件")]
    public GameObject[] Cars;
    [Header("汽車生成點")]
    public GameObject CarCreatPos;
    [Header("汽車生成間隔時間")]
    public float Car_WaitTime;
    [Header("汽車上限")]
    public float Car_MaxNum;
   

    public float CarNum;


    #endregion

    

  



    void Start()
    {
        InvokeRepeating("CreatCars", Car_WaitTime, Car_WaitTime); // 產生汽車
       
    }

    // Update is called once per frame
    void Update()
    {
        // print(thirst);
        
    }

    /// <summary>
    /// 生成汽車
    /// </summary>
    void CreatCars()
    {
        if(CarNum < Car_MaxNum)
        {
            // 生成點的最大最小範圍
            Vector3 MaxValue = CarCreatPos.GetComponent<Collider>().bounds.max;
            Vector3 MinValue = CarCreatPos.GetComponent<Collider>().bounds.min;

            Vector3 randompox = new Vector3(Random.Range(MinValue.x, MaxValue.x), MinValue.y, MinValue.z);

           
            Instantiate(Cars[Random.Range(0, Cars.Length)], randompox, CarCreatPos.transform.rotation);
            
            
            CarNum++;
        }
    }


    public void SerchingPoint() 
    {
        
       // 判斷此搜尋點位置使否有東西
       // 有東西 : 掉出道具

       // 沒有東西: 顯示 "這裡沒有東西..."的訊息

    }

    // 如果玩家進入了搜尋點
    // serchingpoint();

    

}
