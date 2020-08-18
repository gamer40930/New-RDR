using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text QuestText;
    public string QuestName;
    public GameObject CheckMark;


    public bool done;
    public bool showTitle;

    private void Start()
    {
        QuestText.text = "???????";
    }
    private void Update()
    {
        if (done)
        {
            CheckMark.SetActive(true);
            QuestText.text = QuestName;

        }

        if (showTitle)
        {
            QuestText.text = QuestName;
        }
         

    }

    
}
