using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibaryImageBool : MonoBehaviour
{
    public bool[] collections ;
    private Collectionbook CB;

    
    private void Start()
    {
        for (int i = 0; i < collections.Length; i++)
        {
            collections[i] = PlayerPrefs.GetInt("LB" + i) == 1? true: false;
        }
    }

    private void Update()
    {


        for (int i = 0; i < collections.Length; i++)
        {
            PlayerPrefs.SetInt("LB" + i, collections[i] ? 1 : 0); 
        }
    }
}
