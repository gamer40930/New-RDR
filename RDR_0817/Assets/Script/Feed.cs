using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feed : MonoBehaviour
{


    [Header("飽食度數值"), Range(0.01f, 1)]
    public float feed = 0.03f;
    [Header("Eat按鈕")]
    public Button btn;
    [Header("道具加分")]
    public float addscore;

    private Player player;
    private ScoreCount _scoreCount;


    void Start()
    {

        gameObject.transform.parent = null;

        if (player == null)
        {

            //player = GameObject.Find("DOG").GetComponent<Player>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        if (_scoreCount == null)
        {

            _scoreCount = GameObject.Find("GameManger").GetComponent<ScoreCount>();
        }



    }

    // Update is called once per frame
    void Update()
    {

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

    public void Eat()
    {

        //player .ani.SetTrigger("Dog_Eat");
        //player.foodBar.fillAmount += feed;
       
        if(player == null)
        {
            player = GameObject.Find("DOG").GetComponent<Player>();

        }
        else if (player != null)
        {
            player.ani.SetTrigger("Dog_Eat");

            player.foodBar.fillAmount += feed;
            _scoreCount.AddScore(addscore);
            Destroy(gameObject, 0.5f);
        }

        //if (player != null)
        //{

        //    player.Eat(feed);
        //    _scoreCount.AddScore(addscore);
        //    Destroy(gameObject, 0.5f);
        //}



    }
}
