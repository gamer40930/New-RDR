using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collectionbook : MonoBehaviour
{
    private Image backGround; 
    [Header("未解鎖的圖")]
    public Sprite Lock;    
    [Header ("圖鑑選單所有圖片")]
    public Image[] menuimages;
    [Header("解鎖圖")]
    public Sprite[] unLock;
    private LibaryImageBool libaryBool;


    // Start is called before the first frame update
    void Start()
    {
        libaryBool = FindObjectOfType<LibaryImageBool>();
        libaryBool.collections[0] = true;
    }


    private void Update()
    {
        for (int i = 0; i < menuimages.Length; i++)
        {
            for (int k = 0; k < libaryBool.collections.Length; k++)
            {
                // 如果物件 bool = true，圖片就換成UnLock 的圖
                if (libaryBool .collections[i] == true) 
                {
                    menuimages[i].sprite = unLock[i];
                }

                else if (libaryBool.collections[i] == false)
                {
                    menuimages[i].sprite = Lock;
                }
            }
        }
    }

    
    


}
