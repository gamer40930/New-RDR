using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject[] QuestLists;

    [Header("飽食度")]
    public Image foodBar;
    [Header("飽水度")]
    public Image waterBar;

    private void Start()
    {

        QuestLists[0].GetComponent<Quest>().showTitle = true;

    }


    private void Update()
    {

        checkVaule();

        for (int i = 0; i < QuestLists.Length; i++)
        {
            if (QuestLists[i].GetComponent<Quest>().done)
            {
                if ((i+1) < QuestLists.Length)
                {
                    QuestLists[i + 1].GetComponent<Quest>().showTitle = true;
                    print(i + 1);
                }

                else break;
            }
        }
    }

    /// <summary>
    /// 確認飽食度
    /// </summary>
    public void checkVaule()
    {
        if (foodBar.fillAmount > 0.51 || waterBar.fillAmount > 0.51)
        {
            QuestLists[1].GetComponent<Quest>().done = true;
        }
    }

}