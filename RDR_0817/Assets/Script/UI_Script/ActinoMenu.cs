using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActinoMenu : MonoBehaviour
{
    [Header("動作選單")]
    public GameObject actionMenu;
    public Button[] Btn;
    private Player _player;
    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.Find("DOG").GetComponent<Player>();
    }

    private void Update()
    {
        OpenActionMenu();
    }
    public void OpenActionMenu()
    {
        if (Input.GetMouseButtonDown(1))
        {
            actionMenu.SetActive(!actionMenu.activeSelf);
            
        }
        
    }
}
