using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBox : MonoBehaviour
{
    [SerializeField] private Image TurBox;
    [SerializeField] private GameObject _TurBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name =="DOG" && _TurBox != null)
        {
            _TurBox.SetActive(true);
            //TurBox.enabled = true;
            print("開啟圖片");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DOG" && _TurBox != null)
        {
            //TurBox.enabled = false;
            _TurBox.SetActive(false);

        }
        Destroy(TurBox, 2f);
    }

    public void CloseMena()
    {
        _TurBox.SetActive(false);
    }
}
