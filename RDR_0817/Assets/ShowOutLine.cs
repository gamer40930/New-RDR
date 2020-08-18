using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOutLine : MonoBehaviour
{
    public GameObject Outline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DOG")
        {

            print("開啟範圍");
            Outline.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "DOG")
        {

            print("開啟範圍");
            Outline.SetActive(false);

        }
    }


}