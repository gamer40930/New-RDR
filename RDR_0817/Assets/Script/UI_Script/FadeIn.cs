using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    public GameObject canv;
    public Image Fade,BG;
    public Text info;

    
    void Start()
    {
             
        Fade.canvasRenderer.SetAlpha(1.0f);
        BG.canvasRenderer.SetAlpha(1.0f);
        info.canvasRenderer.SetAlpha(1.0f);
        fadeOut();
        
    }

  
    void fadeIn()
    {

        // CrossFadeAlpha( ALPHA值: 0~1, 轉換時間, 是否被TimeScale影響)
        // Fade.CrossFadeAlpha(1, 2,false);
        
        
    }

    void fadeOut()
    {
        // CrossFadeAlpha( ALPHA值: 0~1, 轉換時間, 是否被TimeScale影響)
        Fade.CrossFadeAlpha(0, 2.5f, false);
        BG.CrossFadeAlpha(0, 2.5f, false);
        info.CrossFadeAlpha(0, 3f, false);

        Destroy(gameObject,3.5f);
    }

    
}
