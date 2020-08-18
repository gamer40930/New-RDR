using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class water : MonoBehaviour
{

    [Header("飽水度數值"), Range(0.01f, 1)]
    public float drink = 0.5f;
    [Header("drink按鈕")]
    public Button btn;


    [Header("道具加分")]
    public float addscore;

    public bool reuseble;
    private Player player;
    private ScoreCount _scoreCount;

    private void Start()
    {
        gameObject.transform.parent = null;
        player = GameObject.Find("DOG").GetComponent<Player>();
        _scoreCount = GameObject.Find("GameManger").GetComponent<ScoreCount>();
    }


    private void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.name == "DOG")
        {
            btn.gameObject.SetActive(true);

        }
    }

    private void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name == "DOG")
        {
            btn.gameObject.SetActive(false);

        }
    }


    public void Drink()
    {
        player.Drink(drink);
        _scoreCount.AddScore(addscore);

        if (!reuseble)
        {

            Destroy(gameObject, 0.5f);
        }



    }
}




