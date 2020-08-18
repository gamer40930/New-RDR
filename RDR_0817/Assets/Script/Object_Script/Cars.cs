using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Cars : MonoBehaviour
{
    public float Car_speed;

    [SerializeField]
    BoxCollider carCollider, borderCollider, borderCollider2;
    [SerializeField]
    private GameObject DOG;

    bool stop; // 是否該停車

    float timer = 0; // 計時器
    float timer2 = 0; // 計時器

   

    AudioSource Carhorn;
    // Start is called before the first frame update
    void Start()
    {
        #region 調整大小位置
        gameObject.transform.rotation = Quaternion.Euler(-90, 0, -90);
        gameObject.transform.localScale = new Vector3(150f, 150f, 150f);
        #endregion




        DOG = GameObject.Find("DOG");
        Carhorn = GetComponent<AudioSource>();

        carCollider = GetComponent<BoxCollider>();
        borderCollider = GameObject.Find("Level_ border").GetComponent<BoxCollider>();
        borderCollider2 = GameObject.Find("Level_ border2").GetComponent<BoxCollider>();

        Physics.IgnoreCollision(carCollider, borderCollider);
        Physics.IgnoreCollision(carCollider, borderCollider2);
    }

    // Update is called once per frame
    void Update()
    {
        

        
        
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        float dis = Vector3.Distance(transform.position, DOG.transform.position);

        if (stop && timer> 2f)
        {
            Carhorn.Play();
            timer = 0;

            transform.Translate(Vector3.down * 0);
            if (timer2 > Random.Range (5f,10f))
            {
                
                stop = false;
                timer2 = 0;
            }
        }


        

        if (dis <= 5f && !Carhorn.isPlaying && timer > 1.5f && !stop)
        {
            transform.Translate(Vector3.down * Time.deltaTime * dis);
            timer = 0;


            Carhorn.Play();
        }
        else if (dis > 5f && !stop)
        {
            transform.Translate(Vector3.down * Time.deltaTime * Car_speed);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EDGE")
        {
            Destroy(gameObject, 0.5f);
            GameObject.Find("GameManger").GetComponent<GameManger>().CarNum -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Car_"))
        {
            stop = true;
            print("stop");
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Car_"))
        {
            stop = false;
        }
    }
   
}
