using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;     // 放所有按鈕的清單 (直接自動抓取帶有TabButton 腳本的物件到清單)
    public Sprite tabIdle;                 // 閒置狀態
    public Sprite tabHover;                // 滑鼠移入 
    public Sprite tabActive;               // 滑鼠按下
    public TabButton selectedTab;          // 儲存被選取的按鈕
    public List<GameObject> objectToSwap;  // 用來放選單頁面，隨按鈕切換頁面用
    

    public void Subscribe(TabButton button) 
    {
        if(tabButtons == null) // null 空值
        {
            tabButtons = new List<TabButton>(); // 建立按鈕清單
        }
        tabButtons.Add(button); // 把按鈕加入清單中
    }

    /// <summary>
    /// 滑鼠移到按鈕
    /// </summary>
    /// <param name="button"></param>
    public void OnTabEnter(TabButton button)
    {
        ResetTab(); // 按鈕圖案 = 閒置背景        
        // 確認目前按鈕沒有被點選才能換成滑鼠移入的背景
        if(selectedTab == null || button != selectedTab )
        { 
        button.backgrouond.sprite = tabHover;
        
        } 
    }

    public void OnTabExit(TabButton button)
    {
        ResetTab(); // 按鈕圖案 = 閒置背景
    }

    /// <summary>
    /// 選擇按鈕
    /// </summary>
    /// <param name="button"></param>
    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTab(); // 按鈕圖案 = 閒置背景
        button.backgrouond.sprite = tabActive;

        // GetSiblingIndex : 取該物體在Hierarchy中的層級，可通過參數對其排序
        // index = 存放按鈕組件 的 層級位置 (例如 size 中的 Ellement 0 ,1,2,3.....)
        int index = button.transform.GetSiblingIndex(); 
        for (int i = 0; i < objectToSwap.Count; i++)  // 把objectToSwap 的層級存放在 i 
        {
            if(i == index) // 選到的頁面才開啟顯示  第0個按鈕對應到
            {
                objectToSwap[i].SetActive(true);
            }
            else
            {
                objectToSwap[i].SetActive(false);
            }
        }
        
    }

    /// <summary>
    /// 重置按鈕預設背景
    /// </summary>
    public void ResetTab()
    {
       foreach(TabButton button in tabButtons ) // 給按鈕清單中設定按鈕閒置背景
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.backgrouond.sprite = tabIdle;
        }
    }
}
