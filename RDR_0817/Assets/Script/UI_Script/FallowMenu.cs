using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallowMenu : MonoBehaviour
{
    public GameObject circleMenu;
    

    

    void Update()
    {
        // 讓此menu 跟著目標物件移動
        Vector3 circlePos = Camera.main.WorldToScreenPoint(this.transform.position);
        
            circleMenu.transform.position = circlePos;
        
        
        






    }
}
