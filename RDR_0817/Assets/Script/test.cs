using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class test : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        print("clicked");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Enter");
    }
}
