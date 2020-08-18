using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// 事件系統 : 監視物件的選取、監視輸入模組的使用、監視射線的交互、依照需求更新所有的輸入模組



//這個類一定需要那些組件，如果目前沒有這些組件會被自動加上 ? 確保圖片是否有被加入
[RequireComponent (typeof (Image ))]
public class TabButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    #region 屬性與欄位
    public TabGroup tabGrop;  // 使用TabGruop 腳本
    public Image backgrouond; // 給按鈕分頁使用的背景
    #endregion

    /// <summary>
    /// 選取
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGrop.OnTabSelected(this);
        
    }

    /// <summary>
    /// 滑鼠進入範圍
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGrop.OnTabEnter(this);
        
    }

    /// <summary>
    /// 滑鼠離開
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        tabGrop.OnTabExit(this);
    }

    void Start()
    {
        backgrouond = GetComponent<Image>(); 
        tabGrop.Subscribe(this);
    }

   
}
