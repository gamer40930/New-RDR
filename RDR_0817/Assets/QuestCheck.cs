using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCheck : MonoBehaviour
{
    QuestManager _questManager;

    public GameObject QM;

    [Header("任務編號")]
    public int QuestIndex;
    [Header("是否為觸碰類型任務")]
    public bool IstriggerQuest;


    private void Start()
    {

        _questManager = QM.GetComponent<QuestManager>();
        if (_questManager == null)
        {
            print("_questMAnager miss");
            // _questManager = GameObject.Find("Canvas").GetComponent<QuestManager>();
        }
        //_questManager = GameObject.Find("Canvas").GetComponent<QuestManager>();
        
    }



    private void OnTriggerEnter(Collider Hit)
    {
        

        if (Hit.name == "DOG" && IstriggerQuest)
        {
            if (_questManager.QuestLists[QuestIndex] == null)
            {
                print(_questManager.QuestLists[QuestIndex] + "not fuound");
            }

            else
            {

                _questManager.QuestLists[QuestIndex].GetComponent<Quest>().done = true;
            }

        }
    }
}
